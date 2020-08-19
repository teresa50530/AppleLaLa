using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.Services.ProtfoliosService
{
    public class ProtfoloService
    {
        AppleLaLaModel context = new AppleLaLaModel();
        public OperationResult Create(Protfolio protfolio)
        {
            OperationResult result = new OperationResult();
            try
            {
                AppleLaLaRepository<Protfolio> repo_p = new AppleLaLaRepository<Protfolio>(context);
                var CreateDate = new Protfolio
                {
                    Designer_id = protfolio.Designer_id,
                    Service_details_Id = protfolio.Service_details_Id,
                    Photo_url = protfolio.Photo_url,
                    Year = protfolio.Year,
                    Month = protfolio.Month,
                    Color_type = protfolio.Color_type,
                    Description = protfolio.Description,
                    Create_date = DateTime.Now,
                    Last_updata_date = DateTime.Now,
                };
                repo_p.Create(CreateDate);
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