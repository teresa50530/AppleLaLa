using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.ViewModels
{
    public class DataTableViewModel
    {
        public string ServiceName { get; set; }
        public List<LineChart_Sales> LineChart_Sales { get; set; }
    }

    public class LineChart_Sales
    {
        public string Name { get; set; }
        public string OrderDate { get; set; }
        public decimal? Total { get; set; }
    }

    public class AppointmentData
    {

        public int DesignerId { get; set; }
        public string Name { get; set; }


        [Column(TypeName = "date")]
        public DateTime Appointment_date { get; set; }

        public TimeSpan Start_time { get; set; }
        public string ServiceName { get; set; }
    }
}