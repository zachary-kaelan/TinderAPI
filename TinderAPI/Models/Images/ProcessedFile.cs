using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Images
{
    public class ProcessedFile
    {
        [JilDirective("height")]
        public int Height { get; protected set; }
        [JilDirective("width")]
        public int Width { get; protected set; }
        [JilDirective("url")]
        public string URL { get; protected set; }
    }
}
