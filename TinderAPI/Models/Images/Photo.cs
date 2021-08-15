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
    public class Photo
    {
        internal static readonly RestClient _client = new RestClient("https://images-ssl.gotinder.com/");

        [JilDirective("crop_info")]
        public CropInfo CropInfo { get; protected set; }

        [JilDirective("extension")]
        public string Extension { get; protected set; }
        [JilDirective("fbId")]
        public string FacebookID { get; protected set; }
        [JilDirective("fileName")]
        public string Filename { get; protected set; }
        [JilDirective("id")]
        public string ID { get; protected set; }
        [JilDirective("main")]
        public bool Main { get; protected set; }

        [JilDirective("processedFiles")]
        public ProcessedFile[] ProcessedFiles { get; protected set; }
        [JilDirective("processedVideos")]
        public ProcessedFile[] ProcessedVideos { get; protected set; }

        [JilDirective("url")]
        public string URL { get; protected set; }

        public void DownloadToFolder(string folder)
        {
            File.WriteAllBytes(
                folder.EndsWith("\\") ?
                    folder + Filename :
                    folder + "\\" + Filename
                , _client.DownloadData(
                    new RestRequest(URL)
                )
            );
        }
    }
}
