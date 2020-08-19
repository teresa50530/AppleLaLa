using Dapper;
using MVC_AppleLaLa.Models;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Servicies
{
    public class intoDB
    {
        private AppleLaLaModel context = new AppleLaLaModel();

        
        public void _intoDB(string cartInfo,string Status, string OrderNo,int PayWay_id, int cus_id)
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CartDetail>>(cartInfo);
            AppleLaLaRepository<Order> repo_order = new AppleLaLaRepository<Order>(context);
            AppleLaLaRepository<Order_details> repo_Order_details = new AppleLaLaRepository<Order_details>(context);
            AppleLaLaRepository<Work_schedule> repo_Work_schedule = new AppleLaLaRepository<Work_schedule>(context);
            Order _order = new Order
            {
                Order_id = OrderNo,
                Payway_id = PayWay_id,
                Cust_id = cus_id,
                Order_date = DateTime.Now,
                Last_updata_date = DateTime.Now,
            };
            repo_order.Create(_order);
            context.SaveChanges();

            var SessionId = 0;
            var time = 1;
            foreach (var item in result)
            {

                switch (int.Parse(item.Session))
                {
                    case 11:
                        SessionId = 1;
                        break;
                    case 12:
                        SessionId = 2;
                        break;
                    case 13:
                        SessionId = 3;
                        break;
                    case 14:
                        SessionId = 4;
                        break;
                    case 15:
                        SessionId = 5;
                        break;
                    case 16:
                        SessionId = 6;
                        break;
                    case 17:
                        SessionId = 7;
                        break;
                    case 18:
                        SessionId = 8;
                        break;
                    case 19:
                        SessionId = 9;
                        break;
                    case 20:
                        SessionId = 10;
                        break;
                    case 21:
                        SessionId = 11;
                        break;
                    default:
                        SessionId = 0;
                        break;
                }

                Order_details order_Details = new Order_details()
                {
                    Order_detail_no = DateTimeOffset.Now.AddSeconds(time).ToUnixTimeSeconds().ToString(),
                    Order_id = OrderNo,
                    Service_details_Id = (from sd in context.Service_details
                                          where sd.Name == item.Services
                                          select sd.Service_details_Id).First(),
                    Appointment_date = item.Date,
                    Session_id = SessionId,
                    Designer_id = (from d in context.Designer
                                   where d.Name == item.Designer
                                   select d.Designer_id).First(),
                    Last_updata_date = DateTime.Now,
                };
                repo_Order_details.Create(order_Details);




                var cnstr = ConfigurationManager.ConnectionStrings["AppleLaLaModel"].ConnectionString;
                using (var conn = new SqlConnection(cnstr))
                {
                    conn.Open();
                    string sql = "select ws.Schedule_id, ws.Designer_id,ws.Date,ws.Session_id,ws.On_work_flag from[Work_schedule] ws inner join[Designer] d on ws.Designer_id = d.Designer_id where d.Name = @Name and ws.Date = @Date and ws.Session_id = @Session_id ";

                    var target = conn.Query<dynamic>(sql, new { Name= item.Designer, Date =item.Date, Session_id= SessionId });
                    foreach(var i in target) {

                        Work_schedule Work_schedule = new Work_schedule()
                        {
                            Schedule_id = i.Schedule_id,
                            Designer_id = i.Designer_id,
                            Date = i.Date,
                            Session_id = i.Session_id,
                            On_work_flag = "N"
                        };
                        repo_Work_schedule.Update(Work_schedule);
                    }

                }

                context.SaveChanges();
                time++;
            }
        }
    }
}