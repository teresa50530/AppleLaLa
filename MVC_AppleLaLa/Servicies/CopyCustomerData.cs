using MVC_AppleLaLa.Models;
using MVC_AppleLaLa.Servicies;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Servicies
{
    public class CopyCustomerData
    {
        public OperationResult CopyToCustomer(RegisterViewModel model)
        {
            OperationResult copyResult = new OperationResult();
            try
            {
                AppleLaLaModel context = new AppleLaLaModel();
                AppleLaLaRepository<Customer> repository = new AppleLaLaRepository<Customer>(context);
                
                var copyUser = new Customer
                {
                    Name = model.Name,
                    Account = model.Email,
                    Birthday = model.Birthday,
                    Address = model.Address,
                    Mobile = model.PhoneNumber,
                    Gender = model.Sex,
                    Last_updata_date = DateTime.Now,
                };
                repository.Create(copyUser);
                context.SaveChanges();
                copyResult.IsSuccessful = true;
            }
            catch(Exception ex)
            {
                copyResult.IsSuccessful = false;
                copyResult.exception = ex;
            }
            return copyResult;
        }

        public OperationResult CopyToCustomer(ExternalLoginConfirmationViewModel model)
        {
            OperationResult copyResult = new OperationResult();
            try
            {
                AppleLaLaModel context = new AppleLaLaModel();
                AppleLaLaRepository<Customer> repository = new AppleLaLaRepository<Customer>(context);

                var copyUser = new Customer
                {
                    Name = model.Name,
                    Account = model.Email,
                    Birthday = model.Birthday,
                    Address = model.Address,
                    Mobile = model.PhoneNumber,
                    Gender = model.Sex,
                    Last_updata_date = DateTime.Now,
                };
                repository.Create(copyUser);
                context.SaveChanges();
                copyResult.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                copyResult.IsSuccessful = false;
                copyResult.exception = ex;
            }
            return copyResult;
        }
    }
}