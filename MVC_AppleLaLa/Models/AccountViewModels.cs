using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_AppleLaLa.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "性別")]
        public string Sex { get; set; }
        [Required]
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }
        [Required]
        [Display(Name = "手機")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "輸入10位數並且09開頭的手機號碼")]
        [RegularExpression(@"^09\d{8}$", ErrorMessage = "輸入10位數並且09開頭的手機號碼")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "地址")]
        public string Address { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "代碼")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "記住此瀏覽器?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        //登入
        [Required]
        [Display(Name = "電子郵件")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        //5/20 新增------//
        [Required]
        [Display(Name = "姓名")]
        [DataType(DataType.Text)]
        [StringLength(12, MinimumLength = 2, ErrorMessage = "名字長度為最長12")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "性別")]
        public string Sex { get; set; }

        [Required]
        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Required]
        [Display(Name = "手機")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "地址")]
        [DataType(DataType.Text)]
        public string Address { get; set; }
        //5/20 新增------//

        [Required]
        [EmailAddress(ErrorMessage ="輸入正確的電子信箱格式")]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼和確認密碼不相符。")]
        public string ConfirmPassword { get; set; }



    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼和確認密碼不相符。")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }
}
