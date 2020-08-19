using MVC_AppleLaLa_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.Chart_Interface
{
    interface IRadarChart
    {
        List<RadarChart> GetAllData();
       
    }
}