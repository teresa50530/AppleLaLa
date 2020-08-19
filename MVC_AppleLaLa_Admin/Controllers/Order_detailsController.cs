using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDataLibrary.DB_Model;

namespace MVC_AppleLaLa_Admin.Controllers
{
    //[Authorize(Users = "applelala")]
    public class Order_detailsController : Controller
    {
        private AppleLaLaModel db = new AppleLaLaModel();

        // GET: Order_details
        public ActionResult Index()
        {
            var order_details = db.Order_details.Include(o => o.Order).Include(o => o.Service_details);
            return View(order_details.ToList());
        }

        // GET: Order_details/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_details order_details = db.Order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            return View(order_details);
        }

        // GET: Order_details/Create
        public ActionResult Create()
        {
            ViewBag.Order_id = new SelectList(db.Order, "Order_id", "Order_id");
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name");
            return View();
        }

        // POST: Order_details/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_detail_no,Order_id,Service_details_Id,Appointment_date,Session_id,Designer_id,Coupon_id,Last_updata_date")] Order_details order_details)
        {
            if (ModelState.IsValid)
            {
                db.Order_details.Add(order_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_id = new SelectList(db.Order, "Order_id", "Order_id", order_details.Order_id);
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name", order_details.Service_details_Id);
            return View(order_details);
        }

        // GET: Order_details/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_details order_details = db.Order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_id = new SelectList(db.Order, "Order_id", "Order_id", order_details.Order_id);
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name", order_details.Service_details_Id);
            return View(order_details);
        }

        // POST: Order_details/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_detail_no,Order_id,Service_details_Id,Appointment_date,Session_id,Designer_id,Coupon_id,Last_updata_date")] Order_details order_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_id = new SelectList(db.Order, "Order_id", "Order_id", order_details.Order_id);
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name", order_details.Service_details_Id);
            return View(order_details);
        }

        // GET: Order_details/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_details order_details = db.Order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            return View(order_details);
        }

        // POST: Order_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Order_details order_details = db.Order_details.Find(id);
            db.Order_details.Remove(order_details);
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
