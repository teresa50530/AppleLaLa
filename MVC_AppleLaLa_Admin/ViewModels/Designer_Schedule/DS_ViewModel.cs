using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.ViewModels.Designer_Schedule
{
    public class DS_ViewModel
    {
        public int DesignerId { get; set; }
        public string Name { get; set; }
        public int SessionId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("選擇日期")]
        [Required(ErrorMessage = "請選擇日期")]
        public DateTime WorkDate { get; set; }
        public string WorkFlag { get; set; }

    }


}