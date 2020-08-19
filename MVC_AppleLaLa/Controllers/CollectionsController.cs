using MVC_AppleLaLa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_AppleLaLa.ViewModels;
using MVC_AppleLaLa.Servicies;



namespace MVC_AppleLaLa.Controllers
{
    public class CollectionsController : Controller
    {
        // GET: Collections
        public ActionResult Index()
        {
            CollectionService cservice = new CollectionService();
            Collection_list_ViewModel clvm = new Collection_list_ViewModel();
            clvm.WorksPortfolio = cservice.GetWorks();
            clvm.imgs_Uncategorized = cservice.GetImgs();

            return View(clvm);
        }
    }
}