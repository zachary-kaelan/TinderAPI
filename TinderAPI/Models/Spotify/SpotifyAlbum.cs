using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;
using TinderAPI.Models.Images;

namespace TinderAPI.Models.Spotify
{
    public class SpotifyAlbum : SpotifyThing
    {
        [JilDirective("images")]
        public ProcessedFile[] Images { get; protected set; }
    }
}
