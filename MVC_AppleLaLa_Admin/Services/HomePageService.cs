using MVC_AppleLaLa_Admin.ViewModels.HomePage;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa_Admin.Services
{
    public class HomePageService
    {
        private AppleLaLaModel context = new AppleLaLaModel();

        public TopTiles GetTopTilesData()
        {
            AppleLaLaRepository<Customer> repo_c = new AppleLaLaRepository<Customer>(context);
            AppleLaLaRepository<Designer> repo_d = new AppleLaLaRepository<Designer>(context);
            AppleLaLaRepository<Order_details> repo_od = new AppleLaLaRepository<Order_details>(context);
            AppleLaLaRepository<Order> repo_o = new AppleLaLaRepository<Order>(context);
            TopTiles topTiles = new TopTiles
            {
                MemberCount = repo_c.GetAll().Count(),
                DesginerCount = repo_d.GetAll().Count(),
                AppointmentEvent = repo_od.GetAll().Count((x)=>x.Appointment_date == DateTime.Today),
                OrderMonth = repo_o.GetAll().Count((x) =>x.Order_date.Month == DateTime.Now.Month)
            };
      
            return topTiles;
        }


    }
}