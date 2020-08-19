using MVC_AppleLaLa_Admin.Services;
using MVC_AppleLaLa_Admin.ViewModels;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_AppleLaLa_Admin.Controllers
{

    public class AdminAccountController : Controller
    {
        // GET: AdminAccount
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AdminLogin(AdminLoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            //編碼
            string userName = HttpUtility.HtmlEncode(loginVM.UserName);
            string password = HashService.MD5Hash(HttpUtility.HtmlEncode(loginVM.Password));
            AppleLaLaModel context = new AppleLaLaModel();
            Admin_accounts user = context.Admin_accounts.Where((x) => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (user == null)
            {
                ModelState.AddModelError("", "無效");
                return View(loginVM);
            }

            TempData["Name"] = user.UserName;

            //登入cookie樣版
            var ticket = new FormsAuthenticationTicket(
            version: 1,
            name: user.UserName.ToString(), //可以放使用者Id
            issueDate: DateTime.UtcNow,//現在UTC時間
            expiration: DateTime.UtcNow.AddMinutes(30),//Cookie有效時間=現在時間往後+30分鐘
            isPersistent: true,// 是否要記住我 true or false
            userData: "", //可以放使用者角色名稱
            cookiePath: FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encryptedTicket = FormsAuthentication.Encrypt(ticket); //把驗證的表單加密

            // Create the cookie.
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);

            // Redirect back to original URL.
            var url = FormsAuthentication.GetRedirectUrl(userName, true);

            //return Redirect(FormsAuthentication.GetRedirectUrl(name, true));
            //登入cookie樣版


            return RedirectToAction("Index", "Home");
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}