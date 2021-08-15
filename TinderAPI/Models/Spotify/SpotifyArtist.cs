using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Spotify
{
    public class SpotifyArtist : SpotifyThing
    {
        [JilDirective("top_track")]
        public SpotifyTrack TopTrack { get; protected set; }
        [JilDirective("selected")]
        public bool IsSelected { get; protected set; }
    }
}
