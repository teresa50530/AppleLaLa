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
    public class TableOrdersController : Controller
    {
        private AppleLaLaModel db = new AppleLaLaModel();

        // GET: TableOrders
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CustomerAccountSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.PaywayNameSortParm = sortOrder == "last" ? "last_desc" : "last";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var workers = from w in db.Order
                          select w;
            if (!string.IsNullOrEmpty(searchString))
            {
                workers = workers.Where(w => w.Customer.Account.Contains(searchString)
                || w.Payway.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.Customer.Account);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.Payway.Name);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.Payway.Name);
                    break;
                default:
                    workers = workers.OrderBy(w => w.Customer.Account);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(workers.ToPagedList(pageNumber, pageSize));
        }

        // GET: TableOrders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: TableOrders/Create
        public ActionResult Create()
        {
            ViewBag.Cust_id = new SelectList(db.Customer, "Cust_id", "Account");
            ViewBag.Payway_id = new SelectList(db.Payway, "Payway_id", "Name");
            return View();
        }

        // POST: TableOrders/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_id,Order_date,Cust_id,Payway_id,Last_updata_date")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cust_id = new SelectList(db.Customer, "Cust_id", "Account", order.Cust_id);
            ViewBag.Payway_id = new SelectList(db.Payway, "Payway_id", "Name", order.Payway_id);
            return View(order);
        }

        // GET: TableOrders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cust_id = new SelectList(db.Customer, "Cust_id", "Account", order.Cust_id);
            ViewBag.Payway_id = new SelectList(db.Payway, "Payway_id", "Name", order.Payway_id);
            return View(order);
        }

        // POST: TableOrders/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_id,Order_date,Cust_id,Payway_id,Last_updata_date")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cust_id = new SelectList(db.Customer, "Cust_id", "Account", order.Cust_id);
            ViewBag.Payway_id = new SelectList(db.Payway, "Payway_id", "Name", order.Payway_id);
            return View(order);
        }

        // GET: TableOrders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: TableOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
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
