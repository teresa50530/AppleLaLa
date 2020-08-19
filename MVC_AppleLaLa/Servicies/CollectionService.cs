using MVC_AppleLaLa.ViewModels;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Servicies
{
    public class CollectionService
    {
        private AppleLaLaModel context = new AppleLaLaModel();
        public List<Work> GetWorks() 
        {
            AppleLaLaRepository<Designer> designerWorksInfo = new AppleLaLaRepository<Designer>(context);
            var WorksData = designerWorksInfo.GetAll();
            var worksDetail = (from d in context.Designer
                               join p in context.Protfolio on d.Designer_id equals p.Designer_id
                               join sd in context.Service_details on p.Service_details_Id equals sd.Service_details_Id
                               join st in context.Service_types on sd.Type_id equals st.Type_id
                               join s in context.Service on st.Service_id equals s.Service_id 
                               select new Work { Id = d.Designer_id, DesignerName = d.Name, ServiceName = s.Service_name, BtnbgImg = s.Service_photo_url, WorksPic = p.Photo_url, Introduction = d.Description, DesignerPic = d.Photo_rul }
                               ).ToList();
            var cwList_vm = new Collection_list_ViewModel();
            cwList_vm.WorksPortfolio = worksDetail;
            return worksDetail;
        }
        public List<Uncategorized> GetImgs() 
        {
            AppleLaLaRepository<Protfolio> ImgInfo = new AppleLaLaRepository<Protfolio>(context);
            var protfolioImg = ImgInfo.GetAll().Take(40).Select((x) => new Uncategorized { imgs = x.Photo_url }).ToList();
            var cpList_vm = new Collection_list_ViewModel();
            cpList_vm.imgs_Uncategorized = protfolioImg;
            return protfolioImg;
        }
    }
}