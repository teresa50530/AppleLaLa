using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Models
{

    public class OrderViewModel
    {
        [DisplayName("訂單號碼")]
        public string Order_ID { get; set; }

        [DisplayName("訂單日期")]
        public DateTime Date { get; set; }

        [DisplayName("合計")]
        public decimal Total { get; set; }

        [DisplayName("訂單狀態")]
        public string Status { get; set; }

    }

    public class discount_cash
    {

        [DisplayName("折價券號碼")]
        public string Discount_Id { get; set; }
        [DisplayName("名稱")]
        public string Name { get; set; }
        [DisplayName("日期")]
        public DateTime Date { get; set; }

        [DisplayName("折扣數")]
        public decimal Percent { get; set; }
        public string img_url { get; set; }
    }

    public class Account_List_ViewModel
    {
        [Editable(false)]
        public int Cust_id { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [DataType(DataType.Text)]
        [StringLength(12, MinimumLength = 2, ErrorMessage = "名字長度為最長12")]
        public string Name { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [DataType(DataType.EmailAddress)]
        [Editable(false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [DataType(DataType.Text)]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "長度不正確")]
        public string Address { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "輸入10位數並且09開頭的手機號碼")]
        [RegularExpression(@"^09\d{8}$", ErrorMessage = "輸入10位數並且09開頭的手機號碼")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "必填欄位")]

        [RegularExpression(@"((((19|20)\d{2})/(0?(1|[3-9])|1[012])/(0?[1-9]|[12]\d|30))|(((19|20)\d{2})/(0?[13578]|1[02])/31)|(((19|20)\d{2})/0?2/(0?[1-9]|1\d|2[0-8]))|((((19|20)([13579][26]|[2468][048]|0[48]))|(2000))/0?2/29))$", ErrorMessage = "xxxx/xx/xx")]
        public DateTime Birthday { get; set; }

        public List<OrderViewModel> Order { get; set; }
        public List<discount_cash> Discount { get; set; }

    }
   
       
    
}