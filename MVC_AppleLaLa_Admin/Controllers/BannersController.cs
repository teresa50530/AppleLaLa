using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Imgur.API;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using MVC_AppleLaLa_Admin.Services;
using MVCDataLibrary.DB_Model;

namespace MVC_AppleLaLa_Admin.Controllers
{
    //[Authorize(Users = "applelala")]
    public class BannersController : Controller
    {
        private AppleLaLaModel db = new AppleLaLaModel();

        // GET: Banners
        public ActionResult Index(string searching)
        {
            return View(db.Banner.Where(x => x.Title.Contains(searching) || x.Sut_title.Contains(searching) || x.Text.Contains(searching) || searching == null).ToList());
        }

        // GET: Banners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banner.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // GET: Banners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banners/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Banner1,Title,Sut_title,Text,Banner_photo_url,Last_updata_date")] Banner banner)
        {
            if (ModelState.IsValid)
            {
                BannerService service = new BannerService();
                var result = service.Create(banner);
                if (result.IsSuccessful)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(banner);
        }

        // GET: Banners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banner.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Banners/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Banner1,Title,Sut_title,Text,Banner_photo_url,Last_updata_date")] Banner banner)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(banner).State = EntityState.Modified;
                //db.SaveChanges();
                BannerService service = new BannerService();
                var result = service.Edit(banner);
                if (result.IsSuccessful)
                {
                    return RedirectToAction("Index");
                }
                
            }
            return View(banner);
        }

        // GET: Banners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banner.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banner banner = db.Banner.Find(id);
            db.Banner.Remove(banner);
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
