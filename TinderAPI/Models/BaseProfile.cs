using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;
using TinderAPI.Models;
using TinderAPI.Models.Images;

namespace TinderAPI.Models
{
    public enum Badges
    {
        Selfie_Verified,
        Noonlight_Protected
    }

    public class BaseProfile
    {
        [JilDirective("_id")]
        public string ID { get; protected set; }

        [JilDirective("badges")]
        public Badge[] Badges { get; protected set; }


        [JilDirective("birth_date")]
        public DateTime Birthday { get; protected set; }

        [JilDirective("gender")]
        public int Gender { get; protected set; }
        
        [JilDirective("custom_gender")]
        public string CustomGender { get; protected set; }

        [JilDirective("name")]
        public string Name { get; protected set; }

        [JilDirective("bio")]
        public string Biography { get; protected set; }


        [JilDirective("photos")]
        public Photo[] Photos { get; protected set; }

        [JilDirective("city")]
        public Location Location { get; protected set; }

        [JilDirective("jobs")]
        public Job[] Jobs { get; protected set; }

        [JilDirective("schools")]
        public DisplayableThing[] Schools { get; protected set; }

        [JilDirective("bumper_stickers")]
        public BumperSticker[] BumperStickers { get; protected set; }

        [JilDirective("bumper_sticker_enabled")]
        public bool BumperStickerEnabled { get; protected set; }


        [JilDirective("show_gender_on_profile")]
        public bool ShowGender { get; protected set; }

        [JilDirective("hide_age")]
        public bool HideAge { get; protected set; }

        [JilDirective("hide_distance")]
        public bool HideDistance { get; protected set; }

        [JilDirective("sexual_orientations")]
        public Thing[] SexualOrientations { get; protected set; }

        [JilDirective("is_traveling")]
        public bool IsTraveling { get; protected set; }

    }
}
