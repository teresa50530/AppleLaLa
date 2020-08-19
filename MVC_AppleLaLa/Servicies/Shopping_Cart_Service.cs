using MVC_AppleLaLa.Models;
using MVCDataLibrary.DB_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVC_AppleLaLa.Servicies
{
    public class Shopping_Cart_Service
    {
        private AppleLaLaModel context = new AppleLaLaModel();
        private shop_list_vm shop_list = new shop_list_vm();

        public shop_list_vm GetService(string input)
        {
            string[] ary = input.Split(',');
            var returnList = context.Service_details.Where((x) => ary.Contains(x.Name))
                                .Select((x) => new ShopingCartViewModel { ImgUrl = x.Photo, OrignalPrice = x.Price }).ToList();
            shop_list.Shop_list = returnList;
            return shop_list;

        }

        public shop_list_vm GetCoupon(int Cust_ID)
        {
            var resultCoupon = new Account_List_ViewModel();
            resultCoupon.Discount = (from CCoup in context.Customer_coupon
                                     join detail in context.Coupon on CCoup.Coupon_id equals detail.Coupon_id
                                     where CCoup.Cust_id == Cust_ID
                                     select new discount_cash { Name = detail.Coupon_name, Percent = detail.Discount }).ToList();

            shop_list.Coupon_list = resultCoupon.Discount;

            return shop_list;
        }

        public shop_list_vm GetDesigners()
        {
            var result = (from r in context.Designer
                          select new DesignerViewModel { Designer_Name = r.Name }).ToList();
            shop_list.Designer_list = result;
            return shop_list;
        }

        public Decimal Calculate_Original_Price(List<ShopingCartViewModel> input)
        {
            decimal origin = 0;
            int i = 0;
            string path = @"c:\MyError.txt";

            try
            {
                foreach (var item in input)
                {
                    origin += item.OrignalPrice;
                    if (input.Count - 1 == i)
                    {
                        return origin;
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText(path, ex.ToString());
            }
            return 0;
        }

        public shop_list_vm Get_Session_list()
        {
            var result = (from r in context.Session
                          select new SessionViewModel
                          {
                              Start = r.Start_time,
                              End = r.End_time
                          }).ToList();
            shop_list.Session_list = result;
            return shop_list;
        }

        public List<Work_Schedule_ViewModel> Get_Work_Schedule()
        {

            var result = (from r in context.Work_schedule
                          join d in context.Designer on r.Designer_id equals d.Designer_id
                          join s in context.Session on r.Session_id equals s.Session_id
                          join ds in context.Designer_service on d.Designer_id equals ds.Designer_id
                          select new Work_Schedule_ViewModel
                          {
                              Designer_Name = d.Name,
                              Date = r.Date,
                              Start = s.Start_time,
                              End = s.End_time,
                              On_work = r.On_work_flag,
                          }).Distinct().ToList();

            return result;
        }
    }
}
