using MVC_AppleLaLa.ViewModels.Contant;
using MVCDataLibrary.DB_Model;
using MVCDataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Servicies
{
    public class ContantService
    {
        public List<ContactViewModel> ShopInfo()
        {
            AppleLaLaModel context = new AppleLaLaModel();
            AppleLaLaRepository<Shop> storeInfo = new AppleLaLaRepository<Shop>(context);
            var shopData = storeInfo.GetAll();
            var _returnShopData =
            shopData.Select((x) => new ContactViewModel { Store = x.Name, Adderss = x.Address, Description = x.Description, Phone = x.Mobile, Photo = x.Photo, Tel = x.Tel }).ToList();
            return _returnShopData;
        }
    }
}