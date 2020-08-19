using MVC_AppleLaLa.Models;
using MVC_AppleLaLa.Servicies;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVC_AppleLaLa.Controllers
{
    public class ShippingProcessController : Controller
    {
        // GET: ShippingProcess

        public ActionResult choose_location()
        {
            return View();
        }

        public ActionResult Choose_services_list()
        {
            Choose_service_listServicies Csl_service = new Choose_service_listServicies();
            var data = Csl_service.GetData();

            return View(data);
        }

        [HttpPost]
        public void Get_cart()
        {
            var sr = new StreamReader(Request.InputStream);
            var stream = sr.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var model = js.Deserialize<ShopingCartViewModel>(stream);
            TempData["model"] = model;
        }

        [Authorize]
        public ActionResult shopping_cart()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = (ShopingCartViewModel)TempData["model"];
            var service = new Shopping_Cart_Service();
            var user_name = HttpContext.User.Identity.Name;

            //Product_Price_list
            var get_service_price_model = service.GetService(model.ReserveItem);


            //coupon
            var Account = new AccountDetailService();
            var viewmodel = Account.get_account_detail(user_name);
            var _Coupon = service.GetCoupon(viewmodel.Cust_id);

            //Designer
            var get_designer_model = service.GetDesigners();
            ViewBag.Designers = get_designer_model;

            //Session
            var get_session = service.Get_Session_list();
            ViewBag.Session = get_session;


            ViewBag.Origin = service.Calculate_Original_Price(get_service_price_model.Shop_list);

            ViewBag.Store = model.Store;
            if (!model.ReserveItem.Contains(','))
            {
                ViewBag.Services = model.ReserveItem;
            }
            
            ViewBag.Services = model.ReserveItem.Split(',');
            ViewBag.Coupons = _Coupon;
            return View(get_service_price_model);
        }

        public JsonResult Work_Schedule_JSON()
        {
            var service = new Shopping_Cart_Service();
            var jdata = JsonConvert.SerializeObject(service.Get_Work_Schedule());
            return Json(jdata,JsonRequestBehavior.AllowGet);
        }

    }
}