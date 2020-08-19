using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.ViewModels.Designer_Schedule
{
    public class Schedule_ViewModel
    {
        public DateTime Date { get; set; }
        public int Designer { get; set; }
        public List<int> Sessions { get; set; }
        public string Name { get; set; }

    }
    //public class Schedule_ViewModel_List
    //{
    //    public List<Schedule_ViewModel> item { get; set; }
    //}
}