// #define WEB

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using Jil;
using TinderAPI.Properties;
using TinderAPI.Models;
using TinderAPI.Models.AccountData;
using TinderAPI.Models.Recommendations;

namespace TinderAPI
{
    public static class API
    {
        public static readonly Options _opts = Options.ISO8601ExcludeNullsIncludeInherited;

        static API()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _client.AddDefaultHeader("X-Auth-Token", AUTH_TOKEN);
            //_client.AddDefaultHeader("Origin", "https://tinder.com");
            _client.RemoveDefaultParameter("Accept");
            _client.RemoveDefaultParameter("Accept-Encoding");
            //_client.AddDefaultHeader("Content-type", "application/json");
            _client.AddDefaultHeader("Accept", "*/*");
            _client.AddDefaultHeader("Accept-Encoding", "br, gzip, defalte");
            _client.AddDefaultHeader("Accept-Language", "en-us");
            //_client.AddDefaultParameter("locale", "en", ParameterType.QueryString);

            _client.AddDefaultHeader("user-session-id", "");
            _client.AddDefaultHeader("app-session-time-elapsed", "2.7581539154052734");
            _client.AddDefaultHeader("user-session-time-elapsed", "2.7548550367355347");
            _client.AddDefaultHeader("app-session-id", "");

#if WEB
            _client.AddDefaultHeader("x-supported-image-formats", "jpeg");
            _client.AddDefaultHeader("persistent-device-id", "");
            _client.AddDefaultHeader("platform", "web");
            _client.AddDefaultHeader("tinder-version", "");
            _client.AddDefaultHeader("app-version", "");
#else
            _client.AddDefaultHeader("persistent-device-id", "");
            _client.AddDefaultHeader("platform", "");
            _client.AddDefaultHeader("tinder-version", "");
            _client.AddDefaultHeader("app-version", "");
            _client.AddDefaultHeader("os-version", "");
            _client.AddDefaultHeader("x-supported-image-formats", "webp, jpeg");
#endif

            /*_client.AddDefaultHeader("x-client-version", "10160025");
            _client.AddDefaultHeader("X-Local-UTC-Offset", "-240");
            _client.AddDefaultHeader("Sec-Fetch-Site", "cross-site");
            _client.AddDefaultHeader("Sec-Fetch-Mode", "cors");
            _client.AddDefaultHeader("Sec-Fetch-Dest", "empty");*/

        }

        private static string AUTH_TOKEN = Settings.Default.auth_token;
        private static RestClient _client = new RestClient("https://api.gotinder.com/")
        {
#if WEB
            UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36"
#else
            UserAgent = ""
#endif
        };

        public static void GetNewAuthToken()
        {
            _client.RemoveDefaultParameter("X-Auth-Token");
            var refreshRequest = new RestRequest("v3/auth/login", Method.POST);
            refreshRequest.AddParameter(
                "application/x-google-protobuf",
                "",
                ParameterType.RequestBody
            );
            refreshRequest.AddParameter("locale", "en", ParameterType.QueryString);
            var refreshResult = _client.Execute(refreshRequest);
            var authToken = Regex.Match(refreshResult.Content, "[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}").Value;
            Settings.Default.auth_token = authToken;
            Settings.Default.Save();
            AUTH_TOKEN = authToken;
            _client.AddDefaultHeader("X-Auth-Token", authToken);
        }

        public static void RefreshAuth()
        {
            _client.RemoveDefaultParameter("X-Auth-Token");
            var refreshRequest = new RestRequest("v3/auth/login/sms", Method.POST).AddJsonBody(
                new SMSRefresh()
                {
                    phone_number = "",
                    refresh_token = Settings.Default.refresh_token
                }
            ).AddParameter("locale", "en", ParameterType.QueryString);
            var refreshResult = _client.Execute(refreshRequest);
            var auth = JSON.Deserialize<V2BaseModel<AuthResponse>>(refreshResult.Content, _opts);

            _client.AddDefaultHeader("X-Auth-Token", auth.data.api_token);
            Settings.Default.refresh_token = auth.data.refresh_token;
            Settings.Default.Save();
        }

        public static void FacebookAuth()
        {
            _client.RemoveDefaultParameter("X-Auth-Token");
            var response = _client.Execute(
                new RestRequest("v3/auth/login/facebook").AddJsonBody(
                    new FacebookToken()
                    {
                        facebook_token = ""
                    }
                )
            );
            var auth = JSON.Deserialize<V2BaseModel<AuthResponse>>(response.Content, _opts);
            _client.AddDefaultHeader("X-Auth-Token", auth.data.api_token);
        }

        public static Cooldowns GetCooldowns()
        {
            var response = _client.Execute(
                new RestRequest(
                    "v2/profile?include=likes,super_likes", 
                    Method.GET
                )
            );

            return JSON.Deserialize<V2BaseModel<Cooldowns>>(response.Content, _opts).data;
        }

        public static void UseSuperLikable(string token, string id, long s_number)
        {
            var likeableRequest = new RestRequest(
                    "v1/superlikable",
                    Method.POST
                ).AddParameter(
                    "application/json",
                    JSON.Serialize(
                        new SelectorModel()
                        {
                            token = token,
                            s_number = s_number.ToString(),
                            otherUserId = id,
                            type = "Superlike"
                        },
                        _opts
                    ),
                    ParameterType.RequestBody
                );
            _client.Execute(likeableRequest);
        }

        public static TopPicksResponseData GetTopPicks()
        {
            return JSON.Deserialize<V2BaseModel<TopPicksResponseData>>(
                _client.Execute(
                    new RestRequest(
                        "v2/top-picks/preview", 
                        Method.GET
                    )
                ).Content,
                _opts
            ).data;
        }

        public static bool RateTopPick(long s_number, string id, bool isSuper, out PublicProfile profile)
        {
            var rateRequest = new RestRequest(
                    "v2/top-picks/rate",
                    Method.POST
                ).AddParameter(
                    "application/json",
                    JSON.Serialize(
                        new SelectorModel()
                        {
                            s_number = s_number.ToString(),
                            top_picks = "1",
                            id = id,
                            type = isSuper ? "super" : "like"
                        },
                        _opts
                    ),
                    ParameterType.RequestBody
                );
            var rateResponse = JSON.Deserialize<V2BaseModel<TopPicksRateResponseData>>(
                _client.Execute(rateRequest).Content
            );
            profile = GetPublicProfile(rateResponse.data.UserID);
            return JSON.DeserializeDynamic(rateResponse.data.Response.ToString()).match;
        }

        public static IEnumerable<Recommendation> GetRecommendations()
        {
            V2BaseModel<RecommendationsResponse> curResponse = null;
            while (true)
            {

                int numTries = 0;
                do
                {
                    var response = _client.Execute(
                        new RestRequest(
                            "v2/recs/core",
                            Method.GET
                        )
                    );
                    Thread.Sleep(3000);
                    curResponse = JSON.Deserialize<V2BaseModel<RecommendationsResponse>>(response.Content, _opts);
                    if (numTries == 1 || (numTries > 1 && numTries % 5 == 0))
                    {
                        Console.WriteLine("ERROR - No results, {0} tries", numTries);
                    }
                    if (numTries > 1 && numTries % 3 == 0)
                        GetNewAuthToken();
                    if (numTries > 15)
                        throw new NotImplementedException();
                    ++numTries;
                }
                while (curResponse == null || curResponse.data.Results == null);

                for (int i = 0; i < curResponse.data.Results.Length; ++i)
                {
                    yield return curResponse.data.Results[i];
                }
            }
        }

        public static IEnumerable<Recommendation> GetMyLikes()
        {
            V2BaseModel<RecommendationsResponse> curResponse = null;
            var request = new RestRequest(
                "v2/my-likes",
                Method.GET
            );
            do
            {
                var response = _client.Execute(request);

                curResponse = JSON.Deserialize<V2BaseModel<RecommendationsResponse>>(response.Content, _opts);

                for (int i = 0; i < curResponse.data.Results.Length; ++i)
                {
                    yield return curResponse.data.Results[i];
                }

                request.AddOrUpdateParameter("page_token", curResponse.data.PageToken);
            } while (curResponse.data.Results != null && curResponse.data.Results.Length > 0);
        }

        public static LikeResponse Like(string id, LikeRequest likeRequest)
        {
            var response = _client.Execute(
                new RestRequest("like/" + id, Method.POST).AddParameter(
                    "applcation/json",
                    JSON.Serialize(likeRequest, _opts),
                    ParameterType.RequestBody
                )
            );

            if ((int)response.StatusCode < 400)
                return JSON.Deserialize<LikeResponse>(response.Content, _opts);
            else
                return null;
        }

        public static void Pass(string id, long s_number)
        {
            _client.Execute(
                new RestRequest("pass/" + id).AddParameter(
                    "s_number", 
                    s_number, 
                    ParameterType.QueryString
                )
            );
        }

        public static SuperLikeResponse SuperLike(string id, LikeRequest likeRequest)
        {
            var response = _client.Execute(
                new RestRequest("like/" + id + "/super", Method.POST).AddParameter(
                    "applcation/json",
                    JSON.Serialize(likeRequest, _opts),
                    ParameterType.RequestBody
                )
            );

            if ((int)response.StatusCode < 400 && response.ContentLength > 2)
                return JSON.Deserialize<SuperLikeResponse>(response.Content, _opts);
            else
                return null;
        }

        public static PublicProfile GetPublicProfile(string id)
        {
            var request = new RestRequest("user/" + id);
            request.AddQueryParameter("locale", "en");
            request.AddHeader("Authorization", "Token token=\"" + AUTH_TOKEN + "\"");
            return JSON.Deserialize<V2ResultsModel<PublicProfile>>(
                _client.Execute(request).Content, _opts
            ).results;
        }

        public static int SaveAllRelevantInfo(Recommendation rec, string path, float score)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            bool hasPublicProfile = !rec.User.ID.Contains('-');

            var profile = rec.User;
            Dictionary<string, object> info = new Dictionary<string, object>()
            {
                { "name", profile.Name },
                { "birth_date", profile.Birthday },
                { "score", score },
                { "num_photos", profile.Photos.Length }
            };

            
            if (hasPublicProfile)
            {
                PublicProfile publicProfile = GetPublicProfile(rec.User.ID);
                info.Add("group_matched", publicProfile.GroupMatched);
                if (!String.IsNullOrWhiteSpace(publicProfile.BirthdayInfo))
                    info.Add("birth_date_info", publicProfile.BirthdayInfo);
            }

            if (!String.IsNullOrWhiteSpace(profile.Biography))
                info.Add("bio", profile.Biography);
            var bioScanResults = BioScan(profile.Biography);
            if (bioScanResults != null)
            {
                foreach (var result in bioScanResults)
                {
                    info.Add(result.Key, result.Value);
                }
            }

            if (rec.Instagram != null)
            {
                if (bioScanResults != null && bioScanResults.ContainsKey("instagram"))
                    info.Add("insta_media_count", rec.Instagram.AccountNumPhotos);
                else
                {
                    info.Add(
                        "instagram", new Dictionary<string, object>()
                        {
                            { "username", rec.Instagram.Username },
                            { "media_count", rec.Instagram.AccountNumPhotos },
                            { "last_fetch", rec.Instagram.LastFetch }
                        }
                    );
                    if (score == 0)
                        rec.Instagram.DownloadProfilePicToFolder(path);
                }
            }

            if (profile.Jobs != null && profile.Jobs.Any())
                info.Add("jobs", profile.Jobs);
            if (profile.Schools != null && profile.Schools.Any())
                info.Add("schools", profile.Schools);
            
            if (profile.Location != null)
                info.Add("city", profile.Location);
            if (rec.Distance.HasValue)
                info.Add("distance_mi", rec.Distance.Value);
            if (rec.Type != null)
                info.Add("type", rec.Type);

            if (rec.Facebook.CommonInterests != null && rec.Facebook.CommonInterests.Any())
                info.Add("facebook", rec.Facebook);
            if (rec.Spotify.Connected)
                info.Add(
                    "spotify", new Dictionary<string, object>()
                    {
                        { "theme_track", rec.Spotify.ThemeTrack != null ? rec.Spotify.ThemeTrack.Name : "" },
                        { "num_artists", rec.Spotify.TopArtists == null ? 0 : rec.Spotify.TopArtists.Length }
                    }
                );

            File.WriteAllText(
                JSON.Serialize(info),
                score == 0 ?
                    path + profile.ID + ".json" :
                    path + profile.Name + "_" + profile.Birthday.ToString("yyMMdd") + ".json",
                Encoding.UTF8
            );
            return info.Count;
        }

        public static Dictionary<string, string> BioScan(string bio)
        {
            if (String.IsNullOrWhiteSpace(bio))
                return null;
            Dictionary<string, string> info = new Dictionary<string, string>();

            var matches = Recommendation.RGX_SocialMedia.Matches(bio);
            if (matches.Count > 0)
                info.Add(
                    "Socials",
                    String.Join(
                        ";", matches.Cast<Match>().Select(
                            m => m.Groups[0].Value
                        )
                    )
                );

            return info.Any() ? info : null;
        }
    }
}
