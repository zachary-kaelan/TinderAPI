using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Spotify
{
    public class SpotifyInfo
    {
        [JilDirective("spotify_connected")]
        public bool Connected { get; protected set; }
        [JilDirective("spotify_theme_track")]
        public SpotifyTrack ThemeTrack { get; protected set; }
        [JilDirective("spotify_top_artists")]
        public SpotifyArtist[] TopArtists { get; protected set; }
    }
}
