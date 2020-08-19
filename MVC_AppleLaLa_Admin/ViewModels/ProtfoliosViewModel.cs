using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.ViewModels
{
    public class ProtfoliosViewModel
    {

        public int Protfolio_id { get; set; }

        public int? Designer_id { get; set; }

        public int? Service_details_Id { get; set; }

        public string Photo_url { get; set; }

        public string Year { get; set; }

        public string Month { get; set; }

        public string Description { get; set; }

    }
}