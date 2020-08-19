using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.Services
{
    public class BannerService
    {
        private AppleLaLaModel context = new AppleLaLaModel();
        public OperationResult Edit(Banner banner)
        {
            OperationResult result = new OperationResult();
            try
            {
                AppleLaLaRepository<Banner> repository = new AppleLaLaRepository<Banner>(context);
                var inputData = new Banner
                {
                    Banner1 = banner.Banner1,
                    Title = banner.Title,
                    Sut_title = banner.Sut_title,
                    Banner_photo_url = banner.Banner_photo_url,
                    Text = banner.Text,
                    Last_updata_date = DateTime.Now
                };
                repository.Update(inputData);
                context.SaveChanges();
                result.IsSuccessful = true;
            }
            catch (Exception ex)

            {
                result.IsSuccessful = false;
                result.exception = ex;
            }
            return result;
        }

        public OperationResult Create(Banner banner)
        {
            OperationResult result = new OperationResult();
            try
            {
                AppleLaLaRepository<Banner> repository = new AppleLaLaRepository<Banner>(context);
                var inputData = new Banner
                {
                    Banner1 = banner.Banner1,
                    Title = banner.Title,
                    Sut_title = banner.Sut_title,
                    Banner_photo_url = banner.Banner_photo_url,
                    Text = banner.Text,
                    Last_updata_date = DateTime.Now
                };
                repository.Create(inputData);
                context.SaveChanges();
                result.IsSuccessful = true;
            }
            catch (Exception ex)

            {
                result.IsSuccessful = false;
                result.exception = ex;
            }
            return result;
        }


    }
}