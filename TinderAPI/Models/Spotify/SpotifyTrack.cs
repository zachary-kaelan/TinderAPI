using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Spotify
{
    public class SpotifyTrack : SpotifyThing
    {
        [JilDirective("preview_url")]
        public string PreviewURL { get; protected set; }
        [JilDirective("uri")]
        public string URI { get; protected set; }
        [JilDirective("album")]
        public SpotifyAlbum Album { get; protected set; }
        [JilDirective("artists")]
        public SpotifyThing[] Artists { get; protected set; }
    }
}
