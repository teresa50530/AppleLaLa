using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [StringLength(8, MinimumLength = 3, ErrorMessage = "密碼長度介於3-8字元")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "密碼不一致!")]
        public string ConfirmPassword { get; set; }
    }
}