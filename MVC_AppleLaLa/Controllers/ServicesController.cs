using MVC_AppleLaLa.Servicies;
using MVC_AppleLaLa.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_AppleLaLa.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {
            var service = new Services_Service();
            var viewmodel = service.GetPortfilo();
            var vm = service.GetService();
            List<ServicesViewModel> choose_services = new List<ServicesViewModel>
            {
                new ServicesViewModel { ImgUrl = "../Assets/image/nails.jpg", ClassifyWord = "專業美甲", ClassifyItem = "/ShippingProcess/Choose_location" },
                new ServicesViewModel { ImgUrl = "../Assets/image/Eye-Lash-Banner.jpg", ClassifyWord = "專業美睫", ClassifyItem = "/ShippingProcess/Choose_location" },
                new ServicesViewModel { ImgUrl = "../Assets/image/body.jpg", ClassifyWord = "美體保養", ClassifyItem = "/ShippingProcess/Choose_location" },
                new ServicesViewModel { ImgUrl = "../Assets/image/Mouth.jpg", ClassifyWord = "新式紋繡", ClassifyItem = "/ShippingProcess/Choose_location" },
                new ServicesViewModel { ImgUrl = "../Assets/image/Hair removal.jpg", ClassifyWord = "熱蠟除毛", ClassifyItem = "/ShippingProcess/Choose_location" }
            };
            ViewBag.Services_Title = choose_services;
            ViewBag.service = vm;
            return View(viewmodel);
        }
    }
}