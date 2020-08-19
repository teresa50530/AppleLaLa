using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.ViewModels.Home
{
    public class BannerViewModel
    {
        public string Title { get; set; }
        public string Sut_title { get; set; }
        public string Text { get; set; }
        public string Banner_photo_url { get; set; }
    }

    public class HomeOurServiceViewModel
    {
        public string Service_name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
    }

    public class HomeEnvironmentViewModel
    {
        public string ImgUrl { get; set; }
    }




    //給service的
    public class HomeViewModel
    {
        public List<BannerViewModel> BannerList { get; set; }
        public List<HomeOurServiceViewModel> homeOurServicesList { get; set; }
        public List<HomeEnvironmentViewModel> HomeEnvironmentViewList { get; set; }
    }
}