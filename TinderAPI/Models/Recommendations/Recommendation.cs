using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Jil;
using TinderAPI.Models;
using TinderAPI.Models.Images;
using TinderAPI.Models.Spotify;

namespace TinderAPI.Models.Recommendations
{
    public enum RecInteraction
    {
        Pass,
        Like,
        Super
    }

    [Flags]
    internal enum ProfileInfo
    {
        None = 0,
        Job = 1,
        School = 2,
        Instagram = 4,
        Spotify = 8,
        Gender = 16,
        Bio = 32,
        Photos = 64,
        Social_Media = 128
    }

    public class Recommendation
    {
        public static readonly Regex RGX_SocialMedia = new Regex(
            @"(?:\s+|^)(?:(?:follow|add) me[^\n]+)?(?:(?:insta|snap|ig|sc|AMOS|AMOI|👻)\w*[:\s@-]*|@)[a-z0-9._]{7,30}|" +
            @"(?:\s+|^)[a-z0-9._]{7,30} (?:insta|snap)",
            RegexOptions.IgnoreCase | RegexOptions.Compiled
        );

        [JilDirective("content_hash")]
        public string ContentHash { get; protected set; }

        [JilDirective("s_number")]
        public long SNumber { get; protected set; }

        [JilDirective("type")]
        public string Type { get; protected set; }

        [JilDirective("distance_mi")]
        public int? Distance { get; protected set; }

        [JilDirective("is_superlike_upsell")]
        public bool IsSuperlikeUpsell { get; protected set; }


        [JilDirective("facebook")]
        public Facebook Facebook { get; protected set; }
        [JilDirective("live_ops")]
        public LiveOps LiveOps { get; protected set; }
        [JilDirective("instagram")]
        public InstagramPhotoCollection Instagram { get; protected set; }
        [JilDirective("spotify")]
        public SpotifyInfo Spotify { get; protected set; }


        [JilDirective("teasers")]
        public Teaser[] Teasers { get; protected set; }

        [JilDirective("tinder_u")]
        public TinderU TinderU { get; protected set; }


        [JilDirective("experiment_info")]
        public ExperimentInfo ExperimentInfo { get; protected set; }

        [JilDirective("user")]
        public BaseProfile User { get; protected set; }

        [JilDirective("is_top_pick")]
        public bool IsTopPick { get; set; }

        [JilDirective("tp_type")]
        public int TopPickType { get; protected set; }

        [JilDirective("has_been_superliked")]
        public bool HasBeenSuperliked { get; set; }

        [JilDirective("expire_time")]
        public long ExpireTime { get; set; }

        public string GetCustomID()
        {
            ProfileInfo info = ProfileInfo.None;
            if (User.Jobs.Any())
                info |= ProfileInfo.Job;
            if (User.Schools.Any())
                info |= ProfileInfo.School;
            if (Instagram != null)
                info |= ProfileInfo.Instagram;
            if (Spotify != null && Spotify.Connected)
                info |= ProfileInfo.Spotify;
            if (User.Gender == 1)
                info |= ProfileInfo.Gender;
            if (!String.IsNullOrWhiteSpace(User.Biography))
                info |= ProfileInfo.Bio;
            if (User.Photos.Length > 5)
                info |= ProfileInfo.Photos;
            if (RGX_SocialMedia.IsMatch(User.Biography))
                info |= ProfileInfo.Social_Media;

            return User.Birthday.Year.ToString() + ":" +
                User.Name + ":" +
                ((int)info).ToString();
        }

        /// <summary>
        /// Swipes on a user in the recommendations.
        /// </summary>
        /// <param name="interaction">The type of swipe.</param>
        /// <param name="isMatch">When this method returns, contains whether there was a match or not.</param>
        /// <returns>The rate limit, if out of that type of interaction.</returns>
        public DateTime? Swipe(RecInteraction interaction, out bool isMatch)
        {
            switch (interaction)
            {
                case RecInteraction.Like:
                    var likesResponse = API.Like(
                        User.ID, 
                        new LikeRequest()
                        {
                            content_hash = ContentHash,
                            liked_content_id = User.Photos.First().ID,
                            liked_content_type = "photo",
                            s_number = SNumber
                        }
                    );
                    isMatch = likesResponse.IsMatch;
                    if (likesResponse.RateLimitedUntil.HasValue)
                        return Utils.ConvertUnixTimestamp(likesResponse.RateLimitedUntil.Value);
                    else
                        return null;

                case RecInteraction.Pass:
                    API.Pass(User.ID, SNumber);
                    isMatch = false;
                    return null;

                case RecInteraction.Super:
                    var superLikesResponse = API.SuperLike(
                        User.ID,
                        new LikeRequest()
                        {
                            content_hash = ContentHash,
                            liked_content_id = User.Photos.First().ID,
                            liked_content_type = "photo",
                            s_number = SNumber
                        }
                    );
                    if (superLikesResponse == null)
                    {
                        isMatch = false;
                        return null;
                    }
                    isMatch = superLikesResponse.IsMatch;
                    if (superLikesResponse.LimitExceeded || superLikesResponse.SuperLikes.Remaining == 0)
                        return superLikesResponse.SuperLikes.ResetsAt.ToLocalTime();
                    else
                        return null;

                default:
                    isMatch = false;
                    return null;
            }
        }

        public override string ToString() =>
            String.Format(
                "{0}, {1}, {2} mi",
                User.Name,
                Convert.ToInt32((DateTime.Now - User.Birthday).TotalDays / 365.25),
                Distance ?? -1 
            );
    }
}
