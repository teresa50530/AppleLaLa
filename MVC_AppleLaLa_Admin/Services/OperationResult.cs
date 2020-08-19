using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.Services
{
    public class OperationResult
    {
        public bool IsSuccessful { get; set; }
        public Exception exception { get; set; }

    }
    public static class OperationResultHelper
    {
        public static string Result(this OperationResult value)
        {
            if (value.exception != null)
            {
                string message = value.exception.ToString();
                return message;
            }
            else
            {
                return "沒有存檔";
            }

        }

    }
}