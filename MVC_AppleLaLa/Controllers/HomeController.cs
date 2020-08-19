using MVC_AppleLaLa.Models;
using MVC_AppleLaLa.Servicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_AppleLaLa.ViewModels;
using MVC_AppleLaLa.ViewModels.Home;

namespace MVC_AppleLaLa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            HomePageService homeService = new HomePageService();
            HomeViewModel data = new HomeViewModel();
            data.homeOurServicesList = homeService.GetOurServiceData();
            data.BannerList = homeService.GetBannerData();
            data.HomeEnvironmentViewList = homeService.GetHomeEnvironmentData();
        
            return View(data);
        }

    }
}