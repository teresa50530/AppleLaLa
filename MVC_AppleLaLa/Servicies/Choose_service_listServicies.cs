using MVC_AppleLaLa.ViewModels;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Servicies
{
    public class Choose_service_listServicies
    {
        public List<Choose_services_list_vm> GetData()
        {

            AppleLaLaModel DBContext = new AppleLaLaModel();


            var serviceCollection = (from s in DBContext.Service
                                     join st in DBContext.Service_types on s.Service_id equals st.Service_id
                                     join sd in DBContext.Service_details on st.Type_id equals sd.Type_id
                                     select new Choose_services_list_vm
                                     { Id = s.Service_id,
                                         Service = s.Service_name,
                                         ServicePhoto = s.Service_photo_url,
                                         ServiceTitle = st.Type_name,
                                         ServiceDetail = sd.Name,
                                         Service_Detail_id=sd.Service_details_Id,
                                         WorkDuration = sd.Work_duration,
                                         Price = sd.Price,
                                         portfolios = (from sds in DBContext.Service_details
                                                       join p in DBContext.Protfolio on sds.Service_details_Id equals p.Service_details_Id
                                                       select new Portfolio
                                                       {
                                                           Photo = p.Photo_url,
                                                           ServiceDetailid=p.Service_details_Id
                                                       }).ToList(),
                                         DiscountPrice = sd.Discount_price }) .ToList();

            return serviceCollection;

        }
    }
}