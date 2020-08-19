using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.ViewModels.HomePage
{
    public class HomePageViewModel
    {
        public TopTiles TopTiles { get; set; }


    }

    public class TopTiles
    {
        public int MemberCount { get; set; }

        public int DesginerCount { get; set; }

        public int AppointmentEvent { get; set; }

        public int OrderMonth { get; set; }

    }
}