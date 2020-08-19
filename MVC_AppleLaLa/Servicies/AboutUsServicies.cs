using MVC_AppleLaLa.Models;
using MVC_AppleLaLa.ViewModels.Aboutus;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Servicies
{
    public class AboutUsServicies
    {
        public List<AboutusViewModel> per_one() 
        {
            AppleLaLaModel context = new AppleLaLaModel();
            AppleLaLaRepository<Designer> designer_Info = new AppleLaLaRepository<Designer>(context);
            var persons = designer_Info.GetAll();
            var _returnDesignerInfo =
                persons.Select((x) => new AboutusViewModel { Id = x.Designer_id, DesignerPicURL = x.Photo_rul, DesignerName = x.Name }).ToList();

            return _returnDesignerInfo;
        }
        

    }
}