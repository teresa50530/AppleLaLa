using System.Linq;
using MVC_AppleLaLa.ViewModels;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;


namespace MVC_AppleLaLa.Servicies
{
    public class Services_Service
    {
        public Service_list_ViewModel GetPortfilo()
        {
            var context = new AppleLaLaModel();
            var list = (from re in context.Protfolio
                        orderby re.Last_updata_date descending
                        select new ServicesViewModel
                        {
                            Profilo_img = re.Photo_url,
                            Description = re.Description,
                            Color = re.Color_type
                        }).Take(5).ToList();

            var vm = new Service_list_ViewModel();

            vm.Project = list;

            return vm;
        }


        public Service_list_ViewModel GetService()
        {
            var context = new AppleLaLaModel();
            var repo = new AppleLaLaRepository<Service>(context).GetAll();

            var data = (from r in repo
                        where r.Service_id != 30
                        select new ServicesViewModel
                        {
                            Service_name = r.Service_name,
                            Service_photo = r.Service_photo_url
                        }).Take(3).ToList();

            var result = new Service_list_ViewModel();
            result.three_Service = data;
            return result;
        }
    }
}