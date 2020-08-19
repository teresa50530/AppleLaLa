using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.ViewModels
{
    public class Work
    {
        //Collection_Portfolio
        public string DesignerName { get; set; }
        public string ServiceName { get; set; }
        public string BtnbgImg { get; set; }
        public string WorksPic { get; set; }
        public string Introduction { get; set; }
        public int Id { get; set; }
        public string DesignerPic { get; set; }
    }    

    public class Uncategorized 
    { 
        public string imgs { get; set; }
    }
    public class Collection_list_ViewModel
    {
        public List<Work> WorksPortfolio { get; set; }
        public List<Uncategorized> imgs_Uncategorized { get; set; }
    }

}