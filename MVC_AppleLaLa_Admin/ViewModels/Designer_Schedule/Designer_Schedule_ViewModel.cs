using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.ViewModels.Designer_Schedule
{
    public class Designer_Schedule_ViewModel
    {
        [DisplayName("選擇設計師ID")]
        [Required(ErrorMessage = "請選擇設計師ID")]
        public int DesignerId { get; set; }
        public string Name { get; set; }
        [DisplayName("選擇時段")]
        [Required(ErrorMessage = "請選擇時段")]
        public int SessionId { get; set; } //設計師時段

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("選擇日期")]
        [Required(ErrorMessage = "請選擇日期")]
        public DateTime WorkDate { get; set; }

        [DisplayName("是否上班")]
        [Required(ErrorMessage = "請選擇是否上班")]
        public string WorkFlag { get; set; }



        //----------------------------以下 just for HttpGET (DropDown)--------------------------------------
        //[DisplayName("選擇時段")]
        //[Required(ErrorMessage = "請選擇時段")]
        //public int AllSession { get; set; }//所有時段

        //[DisplayName("設計師ID")]
        //[Required(ErrorMessage = "請選擇設計師ID")]
        public int AllDesignerId { get; set; } //所有設計師Id

    }

    //public class Designer_Schedule_ViewModel_List
    //{
    //    public List<Designer_Schedule_ViewModel> item { get; set; } 
    //}
}