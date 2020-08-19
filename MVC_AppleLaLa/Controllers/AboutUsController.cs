using MVC_AppleLaLa.Servicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_AppleLaLa.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        public ActionResult Index()
        {
                        
            var persons = new AboutUsServicies();
            var person_List = persons.per_one();

            return View(person_List);
        }
    }
}