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
    public class Service_detailsController : Controller
    {
        private AppleLaLaModel db = new AppleLaLaModel();
        // GET: Service_details
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TypeNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.NameSortParm = sortOrder == "last" ? "last_desc" : "last";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var workers = from w in db.Service_details
                          select w;
            if (!string.IsNullOrEmpty(searchString))
            {
                workers = workers.Where(w => w.Service_types.Type_name.Contains(searchString)
                || w.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.Service_types.Type_name);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.Name);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.Name);
                    break;
                default:
                    workers = workers.OrderBy(w => w.Service_types.Type_name);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(workers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Service_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_details service_details = db.Service_details.Find(id);
            if (service_details == null)
            {
                return HttpNotFound();
            }
            return View(service_details);
        }

        // GET: Service_details/Create
        public ActionResult Create()
        {
            ViewBag.Type_id = new SelectList(db.Service_types, "Type_id", "Type_name");
            return View();
        }

        // POST: Service_details/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Service_details_Id,Type_id,Name,Work_duration,Price,Discount_price,Description,Warranty_period,Photo,Unit")] Service_details service_details)
        {
            if (ModelState.IsValid)
            {
                db.Service_details.Add(service_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type_id = new SelectList(db.Service_types, "Type_id", "Type_name", service_details.Type_id);
            return View(service_details);
        }

        // GET: Service_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_details service_details = db.Service_details.Find(id);
            if (service_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type_id = new SelectList(db.Service_types, "Type_id", "Type_name", service_details.Type_id);
            return View(service_details);
        }

        // POST: Service_details/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Service_details_Id,Type_id,Name,Work_duration,Price,Discount_price,Description,Warranty_period,Photo,Unit")] Service_details service_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type_id = new SelectList(db.Service_types, "Type_id", "Type_name", service_details.Type_id);
            return View(service_details);
        }

        // GET: Service_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_details service_details = db.Service_details.Find(id);
            if (service_details == null)
            {
                return HttpNotFound();
            }
            return View(service_details);
        }

        // POST: Service_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service_details service_details = db.Service_details.Find(id);
            db.Service_details.Remove(service_details);
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
