using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Imgur.API.Models.Impl;
using MVC_AppleLaLa_Admin.Services.Designer_Sechdule;
using MVC_AppleLaLa_Admin.ViewModels.Designer_Schedule;
using MVCDataLibrary.DB_Model;
using Newtonsoft.Json;

namespace MVC_AppleLaLa_Admin.Controllers
{
    //[Authorize(Users = "applelala")]
    public class Work_scheduleController : Controller
    {
        public void Tojson(string inputjson)
        {
            var service = new Designer_Schedule_Service();
            var jsondata = JsonConvert.DeserializeObject<List<Schedule_ViewModel>>(inputjson);
            service.DataDesignerSchedule(jsondata);
            //return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        private AppleLaLaModel db = new AppleLaLaModel();

        // GET: Work_schedule

        public ActionResult Index(string schedule_date)
        {
            if(schedule_date == null)
            {
                schedule_date = DateTime.Now.ToString("yyyy/MM/dd");
            }
            //else
            //{
            //    schedule_date = JsonConvert.DeserializeObject(schedule_date).ToString();
            //}
            var work_schedule = db.Work_schedule.Include(w => w.Designer).Include(w => w.Session);
            var service = new Designer_Schedule_Service();

            DateTime date = DateTime.Parse(schedule_date);
            var shortdate = date.ToShortDateString();
            DateTime finaldate = DateTime.Parse(shortdate);
            var result = service.GetListData(finaldate);

            ViewBag.thisdate = finaldate;

            return View(result);
        }

        // GET: Work_schedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_schedule work_schedule = db.Work_schedule.Find(id);
            if (work_schedule == null)
            {
                return HttpNotFound();
            }
            return View(work_schedule);
        }

        // GET: Work_schedule/Create
        public ActionResult Create()
        {
            //ViewBag.Type_id = new SelectList(db.Service_types, "Type_id", "Type_name");
            ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Designer_id");
            ViewBag.Session_id = new SelectList(db.Session, "Session_id", "Start_time");
            return View();
        }

        // POST: Work_schedule/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Schedule_id,Designer_id,Date,Session_id,Reference_order_detail,On_work_flag")] Designer_Schedule_ViewModel work_schedule)
        {
            if (ModelState.IsValid)
            {
                //db.Work_schedule.Add(work_schedule);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Designer_id", work_schedule.Designer_id);
            //ViewBag.Session_id = new SelectList(db.Session, "Session_id", "Start_time", work_schedule.Session_id);
            return View(work_schedule);
        }

        // GET: Work_schedule/Edit/5
        public ActionResult Edit(int? id)//designer id
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer_Schedule_Service service = new Designer_Schedule_Service();
            var work_schedule = service.GetDesginerSchedule(id);
            if (work_schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Name");
            ViewBag.Session_id = new SelectList(db.Session, "Session_id", "Session_id");
            return View(work_schedule);
        }

        // POST: Work_schedule/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string inputjson)
        {
            if (ModelState.IsValid)
            {
                Designer_Schedule_Service service = new Designer_Schedule_Service();

                return RedirectToAction("Index");
            }
            //ViewBag.Designer_id = new SelectList(db.Designer, "Designer_id", "Name", work_schedule.Designer_id);
            //ViewBag.Session_id = new SelectList(db.Session, "Session_id", "Session_id", work_schedule.Session_id);
            return View();
        }

        // GET: Work_schedule/Delete/5
        public ActionResult Delete(int? id, int year, int month, int day)//designer id
        {
            var date = new DateTime(year, month, day);
            
            if (id == null && date == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var work_schedule = db.Work_schedule.Where(x => x.Designer_id == id && x.Date.CompareTo(date) == 0);

            Designer_Schedule_Service service = new Designer_Schedule_Service();
            var d_schedule = service.GetDS_IdnDate(id, date);

            if (work_schedule == null)
            {
                return HttpNotFound();
            }
            return View(d_schedule);
        }

        // POST: Work_schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string inputjson)
        {
            var jsondata = JsonConvert.DeserializeObject<dynamic>(inputjson);

            //if (ModelState.IsValid)
            //{
                var service = new Designer_Schedule_Service();
                var result = service.Deleteschedule(jsondata);

                if (result.IsSuccessful)
                {
                    return RedirectToAction("Index");
                }


           



            //var date = new DateTime(year, month, day);
            //var work_schedule = db.Work_schedule.Where(x => x.Designer_id == id && x.Date.CompareTo(date) == 0);

            //foreach (var item in work_schedule)
            //{
            //    db.Work_schedule.Remove(item);
            //}

            //db.SaveChanges();
            
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
