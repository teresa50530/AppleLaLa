using MVC_AppleLaLa_Admin.Services.DataTableService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_AppleLaLa_Admin.Controllers
{
    //[Authorize(Users = "applelala")]
    public class DataTablesController : Controller
    {
        // GET: DataTables
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataForSales()
        {
            DataForSalesService service = new DataForSalesService();
            return View(service.GetData());
        }

        public ActionResult AppointmentTable()
        {
            DataForSalesService service = new DataForSalesService();
            return View(service.GetAppointmentData());
        }
    }
}