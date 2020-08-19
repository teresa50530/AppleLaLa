using MVC_AppleLaLa_Admin.Services;
using MVC_AppleLaLa_Admin.ViewModels;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_AppleLaLa_Admin.Controllers
{
    [Authorize(Users = "applelala")]
    public class RegisterController : Controller
    {
        private AppleLaLaModel context = new AppleLaLaModel();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "無效");
                return View(registerVM);
            }
            AppleLaLaRepository<Admin_accounts> repository = new AppleLaLaRepository<Admin_accounts>(context);
            Admin_accounts user = new Admin_accounts
            {
                UserName = HttpUtility.HtmlEncode(registerVM.UserName),
                Password = HashService.MD5Hash(HttpUtility.HtmlEncode(registerVM.Password)),
            };
            context.Admin_accounts.Add(user);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}