using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using MVC_AppleLaLa_Admin.Services.ProtfoliosService;
using MVC_AppleLaLa_Admin.ViewModels.Protfolio;
using MVCDataLibrary.DB_Model;
using PagedList;

namespace MVC_AppleLaLa_Admin.Controllers
{
    //[Authorize(Users = "applelala")]
    public class ProtfoliosController : Controller
    {
        private AppleLaLaModel db = new AppleLaLaModel();

        // GET: Protfolios
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DesignerNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.ServiceDetailsNameSortParm = sortOrder == "last" ? "last_desc" : "last";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var workers = from w in db.Protfolio
                          select w;
            if (!string.IsNullOrEmpty(searchString))
            {
                workers = workers.Where(w => w.Designer.Name.Contains(searchString)
                || w.Service_details.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.Designer.Name);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.Service_details.Name);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.Service_details.Name);
                    break;
                default:
                    workers = workers.OrderBy(w => w.Designer.Name);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(workers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Protfolios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protfolio protfolio = db.Protfolio.Find(id);
            if (protfolio == null)
            {
                return HttpNotFound();
            }
            return View(protfolio);
        }

        // GET: Protfolios/Create
        public ActionResult Create()
        {
            ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Name");
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name");
            return View();
        }

        // POST: Protfolios/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Protfolio_id,Designer_id,Service_details_Id,Photo_url,Year,Month,Color_type,Description")] Protfolio protfolio)
        {
            if (ModelState.IsValid)
            {
                ProtfoloService pservice = new ProtfoloService();
                var result = pservice.Create(protfolio);
                if (result.IsSuccessful)
                {
                    return RedirectToAction("Index");
                }
                
            }


            ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Name", protfolio.Designer_id);
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name", protfolio.Service_details_Id);
            return View(protfolio);
        }

        // GET: Protfolios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protfolio protfolio = db.Protfolio.Find(id);
            if (protfolio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Name", protfolio.Designer_id);
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name", protfolio.Service_details_Id);
            return View(protfolio);
        }

        // POST: Protfolios/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Protfolio_id,Designer_id,Service_details_Id,Photo_url,Year,Month,Color_type,Description,Create_date,Last_updata_date")] Protfolio protfolio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(protfolio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Name", protfolio.Designer_id);
            ViewBag.Service_details_Id = new SelectList(db.Service_details, "Service_details_Id", "Name", protfolio.Service_details_Id);
            return View(protfolio);
        }

        // GET: Protfolios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protfolio protfolio = db.Protfolio.Find(id);
            if (protfolio == null)
            {
                return HttpNotFound();
            }
            return View(protfolio);
        }

        // POST: Protfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Protfolio protfolio = db.Protfolio.Find(id);
            db.Protfolio.Remove(protfolio);
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
