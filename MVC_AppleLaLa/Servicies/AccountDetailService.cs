using MVC_AppleLaLa.Models;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System.Linq;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace MVC_AppleLaLa.Servicies
{
    public class AccountDetailService
    {
        private AppleLaLaModel context = new AppleLaLaModel();
        public void Update(Account_List_ViewModel input)
        {
            AppleLaLaRepository<Customer> repository = new AppleLaLaRepository<Customer>(context);
            var account_detail = context.Customer.Find(input.Cust_id);
            account_detail.Name = input.Name;
            account_detail.Mobile = input.Mobile;
            account_detail.Birthday = input.Birthday;
            account_detail.Address = input.Address;
            account_detail.Gender = input.Gender;

            repository.Update(account_detail);
        }

        public Account_List_ViewModel get_account_detail(string user_name)
        {
            AppleLaLaRepository<Customer> repository = new AppleLaLaRepository<Customer>(context);
            var result = new Account_List_ViewModel();
            var ACC = repository.GetAll();
            foreach (var item in ACC)
            {
                if (item.Account == user_name)
                {
                    result.Cust_id = item.Cust_id;
                    result.Name = item.Name;
                    result.Address = item.Address;
                    result.Birthday = item.Birthday;
                    result.Email = item.Account;
                    result.Gender = item.Gender;
                    result.Mobile = item.Mobile;
                    return result;
                }
            }
            return null;
        }

        public Account_List_ViewModel Coupon(int Cust_id)
        {
            var resultCoupon = new Account_List_ViewModel();
            resultCoupon.Discount = (from CCoup in context.Customer_coupon
                                     join detail in context.Coupon on CCoup.Coupon_id equals detail.Coupon_id
                                     where CCoup.Cust_id == Cust_id
                                     select new discount_cash { Name = detail.Coupon_name, Date = CCoup.End_day, Percent = detail.Discount * 10, img_url = detail.Pic }).ToList();
            return resultCoupon;
        }

        //public Account_List_ViewModel GetOrder(int Cust_id)
        //{
        //    var resultList = new Account_List_ViewModel();
        //    var myorder = (context.Order).Where((x) => x.Cust_id == Cust_id).ToList();
        //    var test1 = context.Order_details.Include((d) => d.Service_details).Include((d) => myorder).GroupBy((x) => x.Order_id);

        //    var myOrder = new AppleLaLaRepository<Order>(context).GetAll().Where((x) => x.Cust_id == Cust_id);
        //    var orderDetails = new AppleLaLaRepository<Order_details>(context).GetAll();
        //    var servieDetails = new AppleLaLaRepository<Service_details>(context).GetAll();

        //    resultList.Order = (from mo in myOrder
        //                        join od in orderDetails on mo.Order_id equals od.Order_id
        //                        join sd in servieDetails on od.Service_details_Id equals sd.Service_details_Id
        //                        select new OrderViewModel { Order_ID = mo.Order_id, Date = mo.Last_updata_date, Status = "已付款", Total = sd.Price }).ToList();

        //    return resultList;

        //}

        public dynamic Get_order(int Cust_id)
        {
            var cnstr = ConfigurationManager.ConnectionStrings["AppleLaLaModel"].ConnectionString;
            using (var conn = new SqlConnection(cnstr))
            {
                conn.Open();
                string sql = "select o.Order_id,o.Last_updata_date,sum(sd.Price) as Price from Service_details sd inner join Order_details od on od.Service_details_Id = sd.Service_details_Id inner join [dbo].[Order] o on o.Order_id = od.Order_id where Cust_id = @Cust_id group by o.Order_id,o.Last_updata_date";

                var result = conn.Query<dynamic>(sql, new { Cust_id });
                    
                return result;
            }
        }

    }
}
