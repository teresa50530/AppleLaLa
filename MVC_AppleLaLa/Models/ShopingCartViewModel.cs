using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Models
{
    public class ShopingCartViewModel
    {
        public string Store { get; set; }
        public string ReserveItem { get; set; }

        public string ImgUrl { get; set; }
        public decimal OrignalPrice { get; set; }

    }

    public class DesignerViewModel
    {
        public string Designer_Name { get; set; }
    }

    public class SessionViewModel
    {
        public TimeSpan Start{get;set;}

        public TimeSpan End { get; set; }
    }

    public class Work_Schedule_ViewModel
    {
        public string Designer_Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string On_work { get; set; }
        public string Service_Name { get; set; }
    }


    public class shop_list_vm
    {
        public List<ShopingCartViewModel> Shop_list { get; set; }
        public List<discount_cash> Coupon_list { get; set; }
        public List<DesignerViewModel> Designer_list { get; set; }

        public List<SessionViewModel> Session_list { get; set; }
    }

}

