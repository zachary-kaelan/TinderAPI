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
    public class InstagramPhotoCollection
    {
        [JilDirective("last_fetch_time")]
        public DateTime LastFetch { get; protected set; }
        [JilDirective("completed_initial_fetch")]
        public bool CompletedInitialFetch { get; protected set; }
        [JilDirective("media_count")]
        public int AccountNumPhotos { get; protected set; }
        [JilDirective("profile_picture")]
        public string ProfilePic { get; protected set; }
        [JilDirective("username")]
        public string Username { get; protected set; }

        [JilDirective("photos")]
        public InstagramPhoto[] Photos { get; protected set; }

        public void DownloadProfilePicToFolder(string folder)
        {
            File.WriteAllBytes(
                folder.EndsWith("\\") ?
                    folder + "insta_profile_pic.jpg" :
                    folder + "\\" + "insta_profile_pic.jpg"
                , Photo._client.DownloadData(
                    new RestRequest(ProfilePic)
                )
            );
        }
    }
}
