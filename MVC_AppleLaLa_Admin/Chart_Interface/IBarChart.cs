﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_AppleLaLa_Admin.Chart_Interface
{
    interface IBarChart
    {
        string[] GetLabels();
        decimal[] GetData(string[] name);
    }
}
