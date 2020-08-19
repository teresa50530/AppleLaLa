using MVC_AppleLaLa.Models;
using MVC_AppleLaLa.Servicies;
using System;
using System.Web.Mvc;

namespace MVC_AppleLaLa.Controllers
{
    [Authorize]
    public class AccountDetailController : Controller
    {
        private AccountDetailService Account = new AccountDetailService();
        //GET: AccountDetail
        public ActionResult Index()
        {
            var user_name = HttpContext.User.Identity.Name;
            var viewmodel = Account.get_account_detail(user_name);
            var _order = Account.Get_order(viewmodel.Cust_id);
            var _Coupon = Account.Coupon(viewmodel.Cust_id);
            TempData["ID"] = viewmodel.Cust_id;
            viewmodel.Discount = _Coupon.Discount;
            ViewBag.Order = _order;
            return View(viewmodel);
        }
        

        [HttpPost]
        public ActionResult Index([Bind(Include = ("Name,Email,Phone,Address,Birthday,Mobile,Gender"))] Account_List_ViewModel account_detail)
        {
            if (TempData["ID"] != null)
            {
                var user_name = HttpContext.User.Identity.Name;
                var viewmodel = Account.get_account_detail(user_name);
                var _order = Account.Get_order(viewmodel.Cust_id);
                var _Coupon = Account.Coupon(viewmodel.Cust_id);
                ViewBag.Order = _order;
                account_detail.Discount = _Coupon.Discount;
                account_detail.Cust_id = Convert.ToInt32(TempData["ID"]);
                var service = new AccountDetailService();
                service.Update(account_detail);
            }
            int ID = Convert.ToInt32(TempData["ID"]);

            

            return View(account_detail);
        }

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Order_detail(string ordernum,int Total)
        {
            TempData["Total"] = Total;
            var service = new OrderDetailService();
            var OrderDetail = service.GetOrderDetail(ordernum.Trim());
            return View(OrderDetail);
        }

    }
}