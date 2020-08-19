using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Models
{

    public class ServiceJson
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public string Services { get; set; }
        public string Store { get; set; }
        public string Date { get; set; }
        public string Session { get; set; }
        public string Designer { get; set; }
    }

}