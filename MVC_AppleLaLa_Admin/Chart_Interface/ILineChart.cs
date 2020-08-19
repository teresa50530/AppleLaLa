using MVC_AppleLaLa_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_AppleLaLa_Admin.Chart_Interface
{
    interface ILineChart
    {
        string Title { get; }
        string[] Labels { get; }
        string[] GetArray();
        List<Datasets> GetAll();
    }
}
