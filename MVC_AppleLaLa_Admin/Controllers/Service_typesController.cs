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
    public class Service_typesController : Controller
    {
        private AppleLaLaModel db = new AppleLaLaModel();

        // GET: Service_types
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ServiceNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.ServiceTypeNameSortParm = sortOrder == "last" ? "last_desc" : "last";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var workers = from w in db.Service_types
                          select w;
            if (!string.IsNullOrEmpty(searchString))
            {
                workers = workers.Where(w => w.Service.Service_name.Contains(searchString)
                || w.Type_name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.Service.Service_name);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.Type_name);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.Type_name);
                    break;
                default:
                    workers = workers.OrderBy(w => w.Service.Service_name);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(workers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Service_types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_types service_types = db.Service_types.Find(id);
            if (service_types == null)
            {
                return HttpNotFound();
            }
            return View(service_types);
        }

        // GET: Service_types/Create
        public ActionResult Create()
        {
            ViewBag.Service_id = new SelectList(db.Service, "Service_id", "Service_name");
            return View();
        }

        // POST: Service_types/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Type_id,Type_name,Type_description,Service_id")] Service_types service_types)
        {
            if (ModelState.IsValid)
            {
                db.Service_types.Add(service_types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Service_id = new SelectList(db.Service, "Service_id", "Service_name", service_types.Service_id);
            return View(service_types);
        }

        // GET: Service_types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_types service_types = db.Service_types.Find(id);
            if (service_types == null)
            {
                return HttpNotFound();
            }
            ViewBag.Service_id = new SelectList(db.Service, "Service_id", "Service_name", service_types.Service_id);
            return View(service_types);
        }

        // POST: Service_types/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Type_id,Type_name,Type_description,Service_id")] Service_types service_types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service_types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Service_id = new SelectList(db.Service, "Service_id", "Service_name", service_types.Service_id);
            return View(service_types);
        }

        // GET: Service_types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_types service_types = db.Service_types.Find(id);
            if (service_types == null)
            {
                return HttpNotFound();
            }
            return View(service_types);
        }

        // POST: Service_types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service_types service_types = db.Service_types.Find(id);
            db.Service_types.Remove(service_types);
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
