using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using MVCDataLibrary.DB_Model;

namespace MVC_AppleLaLa_Admin.Services.ChartService
{
    public class HomeBarService

    {

        public string[] GetLabels()
        {
            AppleLaLaModel context = new AppleLaLaModel();
            var labels = context.Service.OrderBy(x => x.Service_id).Select((x) => x.Service_name).ToArray();
            return labels;
        }

        public decimal[] GetData(string[] name)
        {
            AppleLaLaModel context = new AppleLaLaModel();

            var rawData = from od in context.Order_details
                          join sd in context.Service_details on od.Service_details_Id equals sd.Service_details_Id
                          join st in context.Service_types on sd.Type_id equals st.Type_id
                          join s in context.Service on st.Service_id equals s.Service_id
                          select new { s.Service_id, s.Service_name, od.Order_detail_no, sd.Price };
            List<decimal> data = new List<decimal>();
            foreach (var item in name)
            {
                var num = rawData.Where((x) => x.Service_name == item).Sum((x)=>x.Price);
                data.Add(num);
            }
            var result = data.ToArray();
            return result;
        }

    }
}