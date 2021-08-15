using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;
using TinderAPI.Models.Spotify;
using TinderAPI.Models.Images;

namespace TinderAPI.Models
{
    public sealed class PublicProfile
    {
        [JilDirective("_id")]
        public string ID { get; set; }

        [JilDirective("badges")]
        public Badge[] Badges { get; set; }

        [JilDirective("birth_date")]
        public DateTime Birthday { get; set; }
        [JilDirective("gender")]
        public int Gender { get; set; }
        [JilDirective("name")]
        public string Name { get; set; }
        [JilDirective("bio")]
        public string Biography { get; set; }
        [JilDirective("city")]
        public Location Location { get; set; }

        [JilDirective("photos")]
        public Photo[] Photos { get; set; }
        [JilDirective("jobs")]
        public Job[] Jobs { get; set; }
        [JilDirective("schools")]
        public DisplayableThing[] Schools { get; set; }

        [JilDirective("show_gender_on_profile")]
        public bool ShowGender { get; set; }
        [JilDirective("hide_age")]
        public bool HideAge { get; set; }
        [JilDirective("hide_distance")]
        public bool HideDistance { get; set; }

        [JilDirective("group_matched")]
        public bool GroupMatched { get; set; }
        [JilDirective("birth_date_info")]
        public string BirthdayInfo { get; set; }

        [JilDirective("common_friend_count")]
        public int NumCommonFriends { get; set; }
        [JilDirective("common_friends")]
        public CommonThing[] CommonFriends { get; set; }
        [JilDirective("common_like_count")]
        public int NumCommonLikes { get; set; }
        [JilDirective("common_likes")]
        public CommonThing[] CommonLikes { get; set; }
        [JilDirective("connection_count")]
        public int ConnectionCount { get; set; }
        [JilDirective("distance_mi", Ignore = false)]
        public int DistanceMiles { get; set; }

        [JilDirective("instagram")]
        public InstagramPhotoCollection InstagramPhotos { get; set; }

        [JilDirective("spotify_top_artists")]
        public SpotifyArtist[] SpotifyTopArtists { get; set; }
        [JilDirective("spotify_theme_track")]
        public SpotifyTrack SpotifyThemeTrack { get; set; }

        [JilDirective("is_tinder_u")]
        public bool IsTinderU { get; set; }
        [JilDirective("ping_time")]
        public DateTime PingTime { get; set; }
    }

    public class Location
    {
        [JilDirective("name")]
        public string City { get; set; }
        [JilDirective("region")]
        public string State { get; set; }

        public override string ToString() =>
            City ?? "";
    }
}
