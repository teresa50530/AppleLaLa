using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.Models
{
    public class LineChart
    {
        public string Title { get; set; }
        public string[] Labels { get; set; }
        public List<Datasets> Datasets { get; set; }
    }

    public class Datasets
    {
        //label item
        public string Name { get; set; }
        //
        public object[] Data { get; set; }
        public string BorderColor { get; set; }
        public string PointBackgroundColor { get; set; }

    }

}