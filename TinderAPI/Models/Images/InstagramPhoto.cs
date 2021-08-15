using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;
using RestSharp;

namespace TinderAPI.Models.Images
{
    public class InstagramPhoto
    {
        [JilDirective("image")]
        public string Image { get; protected set; }
        [JilDirective("thumbnail")]
        public string Thumbnail { get; protected set; }
        [JilDirective("ts")]
        public string Timestamp { get; protected set; }
        [JilDirective("link")]
        public string InstagramLink { get; protected set; }

        public string DownloadToFolder(string folder)
        {
            var filename = Path.GetFileName(new Uri(Image).LocalPath);
            var path = folder.EndsWith("\\") ?
                    folder + filename :
                    folder + "\\" + filename;
            File.WriteAllBytes(
                path, Photo._client.DownloadData(
                    new RestRequest(Image)
                )
            );
            return path;
        }
    }
}
