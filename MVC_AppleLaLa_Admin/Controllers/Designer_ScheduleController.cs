using MVC_AppleLaLa_Admin.Services.Designer_Sechdule;
using MVC_AppleLaLa_Admin.ViewModels.Designer_Schedule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;
using System.Net;
using MVCDataLibrary.DB_Model;
using PagedList;

namespace MVC_AppleLaLa_Admin.Controllers
{
    //[Authorize(Users = "applelala")]
    public class Designer_ScheduleController : Controller
    {
        //public JsonResult Tojson()
        //{
        //    var service = new Designer_Schedule_Service();
        //    var jsondata = JsonConvert.SerializeObject(service.DataDesignerSchedule());
        //    return Json(jsondata, JsonRequestBehavior.AllowGet);
        //}


        // GET: Designer_Schedule
        public ActionResult Index()
        {
            DateTime today = new DateTime(2020, 6, 18);
            var jjjqqq = DateTime.Now.ToShortDateString();
            ViewBag.Today = today;
            ViewBag.oao = jjjqqq;
            //Designer_Schedule_Service gggg = new Designer_Schedule_Service();
            //var wsData = gggg.GetListData(today);

            return View(/*wsData*/);
        }

        // GET: Designer_Schedule/Details/5
        public ActionResult Details(int? id)
        {

            DateTime today = new DateTime(2020, 6, 18);
            var jjjqqq = DateTime.Now.ToShortDateString();
            var a = Request["schedule_date"];

            ViewBag.aaa = Request.QueryString["aaa"];

            ViewBag.Today = today;
            ViewBag.oao = jjjqqq;
            //Designer_Schedule_Service gggg = new Designer_Schedule_Service();
            //var wsData = gggg.GetListData(today);

            return View(/*wsData*/);
        }

        // GET: Designer_Schedule/Create
        public ActionResult Create()
        {
            //Designer_Schedule_Service service = new Designer_Schedule_Service();
            //ViewBag.Session_id = service.GetAllSession();
            //ViewBag.Designer_id = service.GetAllDesigner();

            return View();
        }

        // POST: Designer_Schedule/Create
        [HttpPost]
        public ActionResult Create(/*[Bind(Include = "AllDesignerId, WorkDate, WorkFlag, SessionId")] */Designer_Schedule_ViewModel model)
        {
            if (ModelState.IsValid)
            {
                //要取得這個Service裡的Create方法的內容結果出來,所以要先new一個Service出來
                Designer_Schedule_Service service = new Designer_Schedule_Service();

                //叫用Service裡的Create方法並且將參數帶入此方法
                var result = service.Create(model);

                //判斷是否操作成功,並顯示結果於畫面上給使用者
                if (result.IsSuccessful)
                {
                    ViewBag.result = "資料新增成功";
                }
                else
                {
                    ViewBag.result = result.exception;
                }
            }
            return View();
        }

        // GET: Designer_Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Designer_Schedule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Designer_Schedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Designer_Schedule/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
