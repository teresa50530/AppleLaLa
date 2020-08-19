using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_AppleLaLa_Admin.Services;
using MVCDataLibrary.DB_Model;
using PagedList;

namespace MVC_AppleLaLa_Admin.Controllers
{
    //[Authorize(Users = "applelala")]
    public class TableDesignersController : Controller
    {
        private AppleLaLaModel db = new AppleLaLaModel();

        // GET: TableDesigners
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.NicknameSortParm = sortOrder == "last" ? "last_desc" : "last";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var workers = from w in db.Designer
                          select w;
            if (!string.IsNullOrEmpty(searchString))
            {
                workers = workers.Where(w => w.Name.Contains(searchString)
                || w.Nickname.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.Name);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.Nickname);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.Nickname);
                    break;
                default:
                    workers = workers.OrderBy(w => w.Name);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(workers.ToPagedList(pageNumber, pageSize));
        }

        // GET: TableDesigners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designer.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        // GET: TableDesigners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableDesigners/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Designer_id,Account,Name,Nickname,Birthday,Address,Mobile,Gender,Hire_day,Description,Photo_rul,Last_updata_date")] Designer designer)
        {
            if (ModelState.IsValid)
            {
                DesignerService service = new DesignerService();
                var result = service.Create(designer);
                if (result.IsSuccessful)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(designer);
        }

        // GET: TableDesigners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designer.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        // POST: TableDesigners/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Designer_id,Account,Name,Nickname,Birthday,Address,Mobile,Gender,Hire_day,Description,Photo_rul,Last_updata_date")] Designer designer)
        {
            if (ModelState.IsValid)
            {
                DesignerService service = new DesignerService();
                var result = service.Edit(designer);
                if (result.IsSuccessful)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(designer);
        }

        // GET: TableDesigners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designer.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        // POST: TableDesigners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designer designer = db.Designer.Find(id);
            db.Designer.Remove(designer);
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
