using MVC_AppleLaLa.ViewModels;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Servicies
{
    public class Choose_service_listService
    {
        public Choose_services_list_vm GetData()
        {
            //1.初始化資料庫的model
            AppleLaLaModel DBContext = new AppleLaLaModel();

            //2.把AppleLaLaRepository定義為Service的型別 並初始化
            AppleLaLaRepository<Service> service = new AppleLaLaRepository<Service>(DBContext);

            //3.叫用Repository內的GetAll()這個方法,並取得資料
            var serviceData = service.GetAll();

            //4.選取需要的欄位,塞給自己的ViewModel,並存給變數
            //var serviceCollection = serviceData.Select(x => new Choose_services_list_vm { })

            //4. 查詢需要的資料表,取得需要的欄位資料,並存成變數 (多個資料表查詢方式)
            //var serviceCollection = from s in DBContext.Service
            //                        join st in DBContext.Service_types on s.Service_id equals st.Service_id
            //                        join sd in DBContext.Service_details on st.Type_id equals sd.Type_id
            //                        select new Choose_services_list_vm 


            ////new自己的ViewModel
            //var i = new Choose_services_list_vm();

            //foreach (var item in repository.GetAll().OrderBy(x => x.Service_id))
            //{
            //    i.Id = item.Service_id;
            //    i.Service = item.Service_name;
            //    i.ServicePhoto = item.Service_photo_url;
            //};
            //return i;
        }
    }
}