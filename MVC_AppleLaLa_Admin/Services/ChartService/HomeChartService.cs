using MVC_AppleLaLa_Admin.Chart_Interface;
using MVC_AppleLaLa_Admin.Models;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace MVC_AppleLaLa_Admin.Services.ChartService
{
    public class HomeChartService :ILineChart
    {
        public string Title => "本月業績曲線圖";
        public string[] Labels => GetArray();

        public List<Datasets> GetAll()
        {
            AppleLaLaModel context = new AppleLaLaModel();
            //var countDays = DateTime.Now.Day;
            AppleLaLaRepository<Service> repo_service = new AppleLaLaRepository<Service>(context);
            var serviceName = repo_service.GetAll();

            List<Datasets> mainData = new List<Datasets>();
            Random color_rgb = new Random();
            foreach (var item in serviceName)
            {
                Datasets datasets = new Datasets();
                datasets.Name = item.Service_name;
                string color_str = string.Empty;
                color_str = $"rgba({color_rgb.Next(1, 255)},{color_rgb.Next(1, 255)},{color_rgb.Next(1, 255)},0.5)";
                datasets.BorderColor = color_str;
                datasets.PointBackgroundColor = color_str;
                datasets.Data = GetDataArray(item.Service_name);
                mainData.Add(datasets);
            }

            return mainData;
        }

        public string[] GetArray()
        {
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            List<string> tmp = new List<string>();
            for (int i = 1; i <= days; i++)
            {
                tmp.Add(i.ToString());
            }
            var result = tmp.ToArray();
            return result;
        }

        public object[] GetDataArray(string KeyName)
        {
            int num = DateTime.Now.Day;
            AppleLaLaModel context = new AppleLaLaModel();
            var rawData = context.ForLineChart.Select(x => new { x.Name, x.Nday, x.Total })
                                              .Where((x) => x.Name == KeyName)
                                              .ToList(); ;
            object[] listRawData = new object[num];
            for(int i = 0; i < listRawData.Length; i++)
            {
                listRawData[i] = 0;
            }

            foreach (var input in rawData)
            {
                listRawData[(int)input.Nday-1] = input.Total;
            }
         
           return listRawData;
        }
    }
}
