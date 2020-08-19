using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.ViewModels
{
    public class ServicesViewModel
    {
        public string ImgUrl { get; set; }
        public string ClassifyWord { get; set; }
        public string ClassifyItem { get; set; }

        public string Profilo_img { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public string Service_name { get; set; }

        public string Service_photo { get; set; }
    }


    public class Service_list_ViewModel
    {
        public List<ServicesViewModel> Project { get; set; }
        public List<ServicesViewModel> three_Service { get; set; }
    }   
}