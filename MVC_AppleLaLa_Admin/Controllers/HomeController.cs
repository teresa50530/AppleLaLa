using MVC_AppleLaLa_Admin.Services;
using MVC_AppleLaLa_Admin.Services.ChartService;
using MVC_AppleLaLa_Admin.ViewModels.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_AppleLaLa_Admin.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize(Users = "applelala")]
        public ActionResult Index()
        {
            HomePageService homePageService = new HomePageService();
            HomePageViewModel homeVM = new HomePageViewModel();
            homeVM.TopTiles = homePageService.GetTopTilesData();
            //HomeChartService homeChartService = new HomeChartService();
            //HomeRadarService homeRadarService = new HomeRadarService();
            //HomeBarService homeBarService = new HomeBarService();

            //ViewBag.ChartLine = homeChartService.GetAll();
            //ViewBag.TitleName = homeChartService.Title;
            //ViewBag.Label = homeChartService.Labels;
            //ViewBag.Radar = homeRadarService.GetAllData();
            //ViewBag.BarLables = homeBarService.GetLabels();
            //ViewBag.BarData = homeBarService.GetData(homeBarService.GetLabels());
            return View(homeVM);
        }
    }
}