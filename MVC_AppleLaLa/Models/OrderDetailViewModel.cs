using System;

namespace MVC_AppleLaLa.Models
{
    public class OrderDetailViewModel
    {
        public string ImgUrl { get; set; }
        public string ReserveItem { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime date { get; set; }
        public string ServicePerson { get; set; }

        public string Coupon_name { get; set; }

        public decimal ItemTotal { get; set; }

        public decimal BthSale { get; set; }

        public decimal ORIGPrice { get; set; }

        public decimal Rebate { get; set; }

        public string Name { get; set; }

        public string Tel { get; set; }

        public string PayMethod { get; set; }
        public string payStatus { get; set; }
       
    }
}