using MVC_AppleLaLa_Admin.ViewModels.Designer_Schedule;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCDataLibrary.Repository;
using System.Data.SqlClient;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace MVC_AppleLaLa_Admin.Services.Designer_Sechdule
{
    public class Designer_Schedule_Service
    {
        ////要new一個dbContext,讓他幫我傳資料給資料庫
        private AppleLaLaModel context = new AppleLaLaModel();
        public OperationResult DataDesignerSchedule(List<Schedule_ViewModel> jsondata)
        {
            OperationResult result = new OperationResult();

            try
            {
                AppleLaLaRepository<Work_schedule> repository = new AppleLaLaRepository<Work_schedule>(context);
                //List<Schedule_ViewModel> workflag = new List<Schedule_ViewModel>();
                List<Work_schedule> wlist = new List<Work_schedule>();

                int id = jsondata[0].Designer;
                var designerSchedules = context.Work_schedule.Where(x => x.Designer_id == id).ToList(); //這個設計師的所有行程(有很多天)
                foreach (var item in jsondata)
                {
                    var Sessions = designerSchedules.Where(x => x.Date == item.Date).ToList(); //這個設計師這天的所有行程
                    foreach (var s in Sessions) s.On_work_flag = "N"; //這個設計師這天的所有行程的是否上班轉換成"N"
                    foreach (var i in item.Sessions) Sessions.FirstOrDefault(x => x.Session_id == i).On_work_flag = "Y"; //再依照jsondata這包從View收回來有上班的資料裡的sessions去找到這個session的是否上班轉換成"Y"
                    foreach (var s in Sessions) repository.Update(s); //將這些是否上班都轉換正確後,Update(這裡的Update是資料庫裡的這個資料表裡逐筆資料row)
                };
                context.SaveChanges();
                result.IsSuccessful = true;


                //foreach (var item in jsondata)  //畫面傳進來修改的所有List
                //{
                //    var designerId = item.Designer; //這個設計師Id
                //    var date = item.Date; //這個設計師的這天
                //    var sessionArr = item.Sessions; //這個設計師這天的所有上班時段

                //for (int i = 0; i < item.Sessions.Length; i++)
                //{
                // workflag = context.Work_schedule
                //.Where(x => x.Designer_id == item.Designer)
                //.Where(x => x.Date == item.Date)
                //.Where(x => x.Session_id == item.Sessions[i])
                //.Select(x => new Schedule_ViewModel
                //{
                //    Onwork = "Y"
                //}).ToList();
                //}
                //};
                //repository.Update();

                //Work_schedule work_Schedule = new Work_schedule()
                //{
                //};


            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.exception = ex;
            }



            //result.item = workflag;
            return result;

            //var data2 = context.Work_schedule.Include(x => x.Designer).Include(x => x.Session)
            //                                 .Select((x) => new DS_ViewModel
            //                                 {
            //                                     DesignerId = x.Designer_id,
            //                                     Name = x.Designer.Name,
            //                                     SessionId = x.Session_id,
            //                                     WorkDate = x.Date,
            //                                     WorkFlag = x.On_work_flag
            //                                 }).ToList();

            //var data = (from w in context.Work_schedule
            //            join d in context.Designer on w.Designer_id equals d.Designer_id
            //            join s in context.Session on w.Session_id equals s.Session_id
            //            select new Designer_Schedule_ViewModel
            //            {
            //                //DesignerId = w.Designer_id,
            //                Name = d.Name,
            //                SessionId = w.Session_id,
            //                WorkDate = w.Date,
            //                WorkFlag = w.On_work_flag,
            //                //Reference_order_detail = w.Reference_order_detail
            //            }
            //           ).ToList();


        }




        public List<Schedule_ViewModel> GetListData(DateTime today)
        {

            //List<Schedule_ViewModel> result = new List<Schedule_ViewModel>();

            var result = context.Work_schedule
                        .Where((x) => x.Date == today).GroupBy(x => x.Designer_id)
                        .Select((x) => new Schedule_ViewModel
                        {
                            Designer = x.Key,
                            Name = context.Designer.FirstOrDefault(y => y.Designer_id == x.Key).Name,
                            Date = today,
                            Sessions = x.OrderBy(y => y.Session_id).Where(y => y.On_work_flag.Equals("Y")).Select(y => y.Session_id).ToList()
                        }).ToList();
            //var result = context.Work_schedule.Include((d) => d.Designer_id)
            //            .Where((x) => x.Date == today)
            //            .Select((x) => new DS_ViewModel
            //            {
            //                Name = x.Designer.Name,
            //                WorkDate = x.Date,
            //                SessionId = x.Session_id,
            //                WorkFlag = x.On_work_flag
            //            }).ToList();

            return result;

        }

        //取所有session
        //public SelectList GetAllSession()
        //{
        //    var result = new SelectList(context.Session, "Session_id", "Start_time");
        //    //var result = context.Session.Include(s => s.Session_id)
        //    //        .Select(x => new Designer_Schedule_ViewModel
        //    //        {
        //    //            AllSession = x.Session_id
        //    //        }).ToList();
        //    return result;
        //}

        //取所有designer_id
        //public SelectList GetAllDesigner()
        //{
        //    var result = new SelectList(context.Designer, "Designer_id", "Name");
        //    //var result = context.Designer.Include(x => x.Designer_id)
        //    //        .Select(x => new Designer_Schedule_ViewModel
        //    //        {
        //    //            AllDesignerId = x.Designer_id
        //    //        }).ToList();
        //    return result;
        //}

        //Create
        public OperationResult Create(Designer_Schedule_ViewModel input)
        {
            OperationResult result = new OperationResult();
            try
            {
                //為了要叫用Repository這個類別的Create方法,所以要new一個Repository出來
                //  ,並且傳入<T>泛型參數,這裡用的參數為要新增內容的資料表名稱
                AppleLaLaRepository<Work_schedule> repository = new AppleLaLaRepository<Work_schedule>(context);

                //為了要對Work_Schedule這個資料表塞資料,所以要new一個Work_Schedule資料表出來
                Work_schedule entity = new Work_schedule()
                {
                    //資料表欄位 = ViewModel欄位

                    Designer_id = input.AllDesignerId,
                    Session_id = input.SessionId,
                    On_work_flag = input.WorkFlag,
                    Date = input.WorkDate
                };

                //叫用repository裡的Create方法,並傳入整理好(符合Work_Schedule這個資料表欄位)的這包資料
                repository.Create(entity);

                //叫dbContext幫我確定儲存好
                context.SaveChanges();

                //當走完以上的步驟都沒有出錯,就表示資料儲存完畢
                //就可以塞個操作成功給result
                result.IsSuccessful = true;
            }
            //有try就一定會有catch去接住例外狀況發生時要做的事情
            catch (Exception ex)
            {
                //進入例外狀況這裡,就代表操作失敗
                //就要塞個操作失敗給result
                result.IsSuccessful = false;

                //將這個被抓到的例外狀況的原因塞給exception這個欄位記錄下來
                result.exception = ex;
            }
            //將Create這個方法的操作結果回傳出去
            return result;
        }


        public List<DS_ViewModel> GetDesginerSchedule(int? d_Id)
        {
            var result = context.Work_schedule.Include((d) => d.Designer_id).Where((x) => x.Designer_id == d_Id)
                .Select((x) => new DS_ViewModel
                {
                    DesignerId = x.Designer_id,
                    Name = x.Designer.Name,
                    SessionId = x.Session_id,
                    WorkFlag = x.On_work_flag,
                    WorkDate = x.Date
                }).ToList();
            return result;
        }

        public List<DS_ViewModel> GetDS_IdnDate(int? d_Id, DateTime date)
        {

            var result = context.Work_schedule.Include((d) => d.Designer_id).Where((x) => x.Designer_id == d_Id && x.Date.CompareTo(date) == 0)
                .Select((x) => new DS_ViewModel
                {
                    DesignerId = x.Designer_id,
                    Name = x.Designer.Name,
                    SessionId = x.Session_id,
                    WorkFlag = x.On_work_flag,
                    WorkDate = x.Date
                }).ToList();
            return result;
        }

        public OperationResult Deleteschedule(dynamic jsondata)
        {
            OperationResult result = new OperationResult();

            //try
            //{
                AppleLaLaRepository<Work_schedule> c = new AppleLaLaRepository<Work_schedule>(context);
                //List<Schedule_ViewModel> workflag = new List<Schedule_ViewModel>();
                List<Work_schedule> wlist = new List<Work_schedule>();

                int id = jsondata.Id;
                DateTime date = jsondata.Date;
            DateTime addD = date.AddDays(1);
            List<Work_schedule> removeData = new List<Work_schedule>();
            removeData = c.GetAll().Where((x) => x.Designer_id == id && x.Date.CompareTo(addD.Date) == 0).ToList();
                var i = 0;
                foreach (var item in removeData)
                {

                    c.Delete(item);
                }

                context.SaveChanges();
                result.IsSuccessful = true;
            //}

            //catch (Exception ex)
            //{
            //    result.IsSuccessful = false;
            //    result.exception = ex;
            //}

            return result;
        }

    }
}