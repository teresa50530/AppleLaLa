using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDataLibrary.DB_Model;
using PagedList;

namespace MVC_AppleLaLa_Admin.Controllers
{
    //[Authorize(Users = "applelala")]
    public class Customer_couponController : Controller
    {
        private AppleLaLaModel db = new AppleLaLaModel();

        // GET: Customer_coupon
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CouponNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.CustomerAccountSortParm = sortOrder == "last" ? "last_desc" : "last";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var workers = from w in db.Customer_coupon
                          select w;
            if (!string.IsNullOrEmpty(searchString))
            {
                workers = workers.Where(w => w.Coupon.Coupon_name.Contains(searchString)
                || w.Customer.Account.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.Coupon.Coupon_name);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.Customer.Account);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.Customer.Account);
                    break;
                default:
                    workers = workers.OrderBy(w => w.Coupon.Coupon_name);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(workers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Customer_coupon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_coupon customer_coupon = db.Customer_coupon.Find(id);
            if (customer_coupon == null)
            {
                return HttpNotFound();
            }
            return View(customer_coupon);
        }

        // GET: Customer_coupon/Create
        public ActionResult Create()
        {
            ViewBag.Coupon_id = new SelectList(db.Coupon, "Coupon_id", "Coupon_name");
            ViewBag.Cust_id = new SelectList(db.Customer, "Cust_id", "Account");
            return View();
        }

        // POST: Customer_coupon/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cust_id,Coupon_id,End_day,Start_day")] Customer_coupon customer_coupon)
        {
            if (ModelState.IsValid)
            {
                db.Customer_coupon.Add(customer_coupon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Coupon_id = new SelectList(db.Coupon, "Coupon_id", "Coupon_name", customer_coupon.Coupon_id);
            ViewBag.Cust_id = new SelectList(db.Customer, "Cust_id", "Account", customer_coupon.Cust_id);
            return View(customer_coupon);
        }

        // GET: Customer_coupon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_coupon customer_coupon = db.Customer_coupon.Find(id);
            if (customer_coupon == null)
            {
                return HttpNotFound();
            }
            ViewBag.Coupon_id = new SelectList(db.Coupon, "Coupon_id", "Coupon_name", customer_coupon.Coupon_id);
            ViewBag.Cust_id = new SelectList(db.Customer, "Cust_id", "Account", customer_coupon.Cust_id);
            return View(customer_coupon);
        }

        // POST: Customer_coupon/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cust_id,Coupon_id,End_day,Start_day")] Customer_coupon customer_coupon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_coupon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Coupon_id = new SelectList(db.Coupon, "Coupon_id", "Coupon_name", customer_coupon.Coupon_id);
            ViewBag.Cust_id = new SelectList(db.Customer, "Cust_id", "Account", customer_coupon.Cust_id);
            return View(customer_coupon);
        }

        // GET: Customer_coupon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_coupon customer_coupon = db.Customer_coupon.Find(id);
            if (customer_coupon == null)
            {
                return HttpNotFound();
            }
            return View(customer_coupon);
        }

        // POST: Customer_coupon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_coupon customer_coupon = db.Customer_coupon.Find(id);
            db.Customer_coupon.Remove(customer_coupon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
