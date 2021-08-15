using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Images
{
    public class CropInfo
    {
        [JilDirective("processed_by_bullseye")]
        public bool BullseyeProcessed { get; protected set; }
        [JilDirective("user_customized")]
        public bool Customized { get; protected set; }
        [JilDirective("algo")]
        public CropAlgorithm Algorithm { get; protected set; }
        [JilDirective("user")]
        public PhotoUser User { get; protected set; }
    }

    public class CropAlgorithm
    {
        public double height_pct { get; set; }
        public double width_pct { get; set; }
        public double x_offset_pct { get; set; }
        public double y_offset_pct { get; set; }
    }

    public struct PhotoUser
    {
        public float height_pct { get; set; }
        public float width_pct { get; set; }
        public float x_offset_pct { get; set; }
        public float y_offset_pct { get; set; }
    }
}
