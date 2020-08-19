using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.ViewModels
{
    public class Portfolio
    {
        public string Photo { get; set; }
        public int? ServiceDetailid { get; set; }
    }
    public class Choose_services_list_vm
    {
        public int Id { get; set; }
        public string Service { get; set; }
        public string ServicePhoto { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDetail { get; set; }
        public int Service_Detail_id { get; set; }
        public int WorkDuration { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public List<Portfolio> portfolios { get; set; }
    }
}