using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.Services
{
    public class DesignerService
    {
        private AppleLaLaModel context = new AppleLaLaModel();
        public OperationResult Edit(Designer designer)
        {
            OperationResult result = new OperationResult();
            try
            {
                AppleLaLaRepository<Designer> repository = new AppleLaLaRepository<Designer>(context);
                var inputData = new Designer
                {
                    Designer_id = designer.Designer_id,
                    Account = designer.Account,
                    Name = designer.Name,
                    Nickname = designer.Nickname,
                    Birthday = designer.Birthday,
                    Address = designer.Address,
                    Mobile = designer.Mobile,
                    Gender = designer.Gender,
                    Hire_day = designer.Hire_day,
                    Description = designer.Description,
                    Photo_rul = designer.Photo_rul,
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

        public OperationResult Create(Designer designer)
        {
            OperationResult result = new OperationResult();
            try
            {
                AppleLaLaRepository<Designer> repository = new AppleLaLaRepository<Designer>(context);
                var inputData = new Designer
                {
                    Designer_id = designer.Designer_id,
                    Account = designer.Account,
                    Name = designer.Name,
                    Nickname = designer.Nickname,
                    Birthday = designer.Birthday,
                    Address = designer.Address,
                    Mobile = designer.Mobile,
                    Gender = designer.Gender,
                    Hire_day = designer.Hire_day,
                    Description = designer.Description,
                    Photo_rul = designer.Photo_rul,
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