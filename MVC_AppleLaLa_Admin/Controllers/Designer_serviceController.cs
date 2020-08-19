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
    public class Designer_serviceController : Controller
    {
        private AppleLaLaModel db = new AppleLaLaModel();

        // GET: Designer_service
        public ActionResult Index()
        {
            var designer_service = db.Designer_service.Include(d => d.Designer).Include(d => d.Service).Include(d => d.Service_details).Include(d => d.Service_types);
            return View(designer_service.ToList());
        }

        // GET: Designer_service/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer_service designer_service = db.Designer_service.Find(id);
            if (designer_service == null)
            {
                return HttpNotFound();
            }
            return View(designer_service);
        }

        // GET: Designer_service/Create
        public ActionResult Create()
        {
            ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Account");
            ViewBag.Service_id = new SelectList(db.Service, "Service_id", "Service_name");
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name");
            ViewBag.Service_type_id = new SelectList(db.Service_types, "Type_id", "Type_name");
            return View();
        }

        // POST: Designer_service/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Designer_id,Last_updata_date,Service_details_Id,Service_type_id,Service_id")] Designer_service designer_service)
        {
            if (ModelState.IsValid)
            {
                db.Designer_service.Add(designer_service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Account", designer_service.Designer_id);
            ViewBag.Service_id = new SelectList(db.Service, "Service_id", "Service_name", designer_service.Service_id);
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name", designer_service.Service_details_Id);
            ViewBag.Service_type_id = new SelectList(db.Service_types, "Type_id", "Type_name", designer_service.Service_type_id);
            return View(designer_service);
        }

        // GET: Designer_service/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer_service designer_service = db.Designer_service.Find(id);
            if (designer_service == null)
            {
                return HttpNotFound();
            }
            ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Account", designer_service.Designer_id);
            ViewBag.Service_id = new SelectList(db.Service, "Service_id", "Service_name", designer_service.Service_id);
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name", designer_service.Service_details_Id);
            ViewBag.Service_type_id = new SelectList(db.Service_types, "Type_id", "Type_name", designer_service.Service_type_id);
            return View(designer_service);
        }

        // POST: Designer_service/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Designer_id,Last_updata_date,Service_details_Id,Service_type_id,Service_id")] Designer_service designer_service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designer_service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Account", designer_service.Designer_id);
            ViewBag.Service_id = new SelectList(db.Service, "Service_id", "Service_name", designer_service.Service_id);
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name", designer_service.Service_details_Id);
            ViewBag.Service_type_id = new SelectList(db.Service_types, "Type_id", "Type_name", designer_service.Service_type_id);
            return View(designer_service);
        }

        // GET: Designer_service/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer_service designer_service = db.Designer_service.Find(id);
            if (designer_service == null)
            {
                return HttpNotFound();
            }
            return View(designer_service);
        }

        // POST: Designer_service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designer_service designer_service = db.Designer_service.Find(id);
            db.Designer_service.Remove(designer_service);
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
