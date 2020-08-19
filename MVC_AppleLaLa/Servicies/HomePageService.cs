using MVC_AppleLaLa.ViewModels.Home;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Servicies
{
    public class HomePageService
    {
        
        public List<HomeOurServiceViewModel> GetOurServiceData()
        {

            AppleLaLaModel context = new AppleLaLaModel();
            AppleLaLaRepository<Service> service = new AppleLaLaRepository<Service>(context);

            var serviceData = service.GetAll();

            var returnData =
                 serviceData.Select((x) => new HomeOurServiceViewModel { Service_name = x.Service_name, Description = x.Description, ImgUrl = x.Service_photo_url }).ToList();

            return returnData;
          
        }

      public List<HomeEnvironmentViewModel> GetHomeEnvironmentData()
        {

            AppleLaLaModel context = new AppleLaLaModel();
            AppleLaLaRepository<MVCDataLibrary.DB_Model.Environment> Environment = new AppleLaLaRepository<MVCDataLibrary.DB_Model.Environment>(context);

            var EnvironmentData = Environment.GetAll();

            var returnEnvironmentData =EnvironmentData.Select((x) => new HomeEnvironmentViewModel {  ImgUrl = x.Environment_photo}).ToList();


            return returnEnvironmentData;

        }

        public List<BannerViewModel> GetBannerData()
        {
            AppleLaLaModel homePage = new AppleLaLaModel();
            AppleLaLaRepository<Banner> repository_b = new AppleLaLaRepository<Banner>(homePage);
            List<BannerViewModel> returnData = repository_b.GetAll()
                                .Select((x) => new BannerViewModel
                                {
                                    Title = x.Title,
                                    Sut_title = x.Sut_title,
                                    Text = x.Text,
                                    Banner_photo_url = x.Banner_photo_url
                                }).ToList();
            return returnData;
        }
             

      

}
}