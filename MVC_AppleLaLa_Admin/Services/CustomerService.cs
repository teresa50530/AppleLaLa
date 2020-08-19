using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.Services
{
    public class CustomerService
    {
        private AppleLaLaModel context = new AppleLaLaModel();
        public OperationResult Edit(Customer customer)
        {
            OperationResult result = new OperationResult();
            try
            {
                AppleLaLaRepository<Customer> repository = new AppleLaLaRepository<Customer>(context);
                var inputData = new Customer
                {
                    Cust_id = customer.Cust_id,
                    Account = customer.Account,
                    Name = customer.Name,
                    Birthday = customer.Birthday,
                    Address = customer.Address,
                    Mobile = customer.Mobile,
                    Gender = customer.Gender,
                    Last_updata_date = DateTime.Now,
                    Coupon_id = customer.Coupon_id
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

        public OperationResult Create(Customer customer)
        {
            OperationResult result = new OperationResult();
            try
            {
                AppleLaLaRepository<Customer> repository = new AppleLaLaRepository<Customer>(context);
                var inputData = new Customer
                {
                    Cust_id = customer.Cust_id,
                    Account = customer.Account,
                    Name = customer.Name,
                    Birthday = customer.Birthday,
                    Address = customer.Address,
                    Mobile = customer.Mobile,
                    Gender = customer.Gender,
                    Last_updata_date = DateTime.Now,
                    Coupon_id = customer.Coupon_id
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