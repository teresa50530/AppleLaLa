using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.Models
{

    public class RadarChart
    {
        public string[] Labels { get; set; }
        public Dataset[] Datasets { get; set; }
    }

    public class Dataset
    {
        public string Label { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
        public string PointBorderColor { get; set; }
        public string PointBackgroundColor { get; set; }
        public string PointHoverBackgroundColor { get; set; }
        public string PointHoverBorderColor { get; set; }
        public int[] Data { get; set; }
    }

}