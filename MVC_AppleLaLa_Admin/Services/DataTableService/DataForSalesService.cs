using MVC_AppleLaLa_Admin.ViewModels;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.Services.DataTableService
{
    public class DataForSalesService
    {
        AppleLaLaModel context = new AppleLaLaModel();
        public List<LineChart_Sales> GetData()
        {
            var result = context.ForLineChart.Select((x) => new LineChart_Sales
            {
                Name = x.Name,
                OrderDate = x.OrderDate,
                Total = x.Total
            }).OrderBy((x) => x.OrderDate).ToList();
            return result;
        }

        public List<AppointmentData> GetAppointmentData()
        {
            var result = (from od in context.Order_details
                         join d in context.Designer on od.Designer_id equals d.Designer_id
                         join se in context.Session on od.Session_id equals se.Session_id
                         join sd in context.Service_details on od.Service_details_Id equals sd.Service_details_Id
                         orderby od.Appointment_date, d.Designer_id
                         select new AppointmentData
                         {
                             DesignerId = od.Designer_id,
                             Name = d.Name,
                             Appointment_date = od.Appointment_date,
                             Start_time = se.Start_time,
                             ServiceName = sd.Name
                         }).ToList();
            return result;
        }
    }

}