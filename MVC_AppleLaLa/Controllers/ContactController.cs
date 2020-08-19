using MVC_AppleLaLa.Servicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_AppleLaLa.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ContantService cservice = new ContantService();
            var detail = cservice.ShopInfo();
            return View(detail);
            
        }
    }
}