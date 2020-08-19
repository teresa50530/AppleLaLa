using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.ViewModels.Protfolio
{
    public class ProtfolioViewModel
    {
        public int DesignerId { get; set; }

        public int ServiceDetailsId { get; set; }

        public string PhotoURL { get; set; }

        public string Year { get; set; }
        public string Month { get; set; }
        public string ColorType { get; set; }
        public string Description { get; set; }
    }

}