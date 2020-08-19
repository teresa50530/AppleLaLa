using MVC_AppleLaLa.Models;
using MVCDataLibrary.DB_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Servicies
{
    public class OrderDetailService
    {
        private AppleLaLaModel context = new AppleLaLaModel();

        public List<OrderDetailViewModel> GetOrderDetail(string ordernum)
        {
            var resultList = (from o in context.Order
                         join ct in context.Customer on o.Cust_id equals ct.Cust_id
                         join p in context.Payway on o.Payway_id equals p.Payway_id
                         join od in context.Order_details on o.Order_id equals od.Order_id
                         //join c in context.Coupon on od.Coupon_id equals c.Coupon_id
                         join d in context.Designer on od.Designer_id equals d.Designer_id
                         join s in context.Session on od.Session_id equals s.Session_id
                         join sd in context.Service_details on od.Service_details_Id equals sd.Service_details_Id
                         where od.Order_id == ordernum
                         select new OrderDetailViewModel()
                         {
                             ImgUrl = sd.Photo,
                             ReserveItem = sd.Name,
                             Time = s.Start_time,
                             date = od.Appointment_date,
                             ServicePerson = d.Name,
                             ItemTotal = sd.Price,
                             //Coupon_name=c.Coupon_name,
                             //BthSale = c.Discount * 10,
                             ORIGPrice = sd.Price,
                             //Rebate = sd.Price- (c.Discount * sd.Price),
                             Name = ct.Name,
                             Tel = ct.Mobile,
                             PayMethod = p.Name,
                             payStatus = "已付款"
                         }).ToList();

            return resultList;
        }
    }
}