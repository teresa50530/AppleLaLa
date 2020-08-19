using Microsoft.Ajax.Utilities;
using MVC_AppleLaLa_Admin.Chart_Interface;
using MVC_AppleLaLa_Admin.Models;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.Services.ChartService
{
    public class HomeRadarService : IRadarChart
    {
        public List<RadarChart> GetAllData()
        {
            List<RadarChart> radarCharData = new List<RadarChart>
            {
                new RadarChart
                {
                    Labels = GetLabels(),
                    Datasets = new Dataset[]{ GetDataset() }
                }
            };
            return radarCharData;

        }

        public string[] GetLabels()
        {
            AppleLaLaModel context = new AppleLaLaModel();
            var labels = context.Service.OrderBy(x=>x.Service_id).Select((x) => x.Service_name).ToArray();
            return labels;
        }


        public Dataset GetDataset()
        {
            Dataset mainData = new Dataset()
            {
                Label = "總件數",
                BackgroundColor = "rgba(3, 88, 106, 0.2)",
                BorderColor = "rgba(3, 88, 106, 0.80)",
                PointBorderColor = "rgba(3, 88, 106, 0.80)",
                PointBackgroundColor = "rgba(3, 88, 106, 0.80)",
                PointHoverBackgroundColor = "#fff",
                PointHoverBorderColor = "rgba(220,220,220,1)",
                Data = GetData(GetLabels())

            };
            return mainData;
        }

        public int[] GetData(string[] name)
        {
            AppleLaLaModel context = new AppleLaLaModel();

            var rawData = from od in context.Order_details
                          join sd in context.Service_details on od.Service_details_Id equals sd.Service_details_Id
                          join st in context.Service_types on sd.Type_id equals st.Type_id
                          join s in context.Service on st.Service_id equals s.Service_id
                          select new { s.Service_id,s.Service_name, od.Order_detail_no, sd.Price };
            List<int> data = new List<int>();
            foreach( var item in name)
            {
                var num = rawData.Where((x) => x.Service_name == item).Count();
                data.Add(num);
            }
            var result = data.ToArray();
            return result;
        }
    }
}