using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutService _aboutService;

        public AboutManager(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public void TAdd(About entity)
        {
            _aboutService.TAdd(entity);
            
        }

        public void TDelete(About entity)
        {
            _aboutService.TDelete(entity);
        }

        public About TGetByID(int id)
        {
            return _aboutService.TGetByID(id);
        }

        public List<About> TGetListAll()
        {
            return _aboutService.TGetListAll();
        }

        public void TUpdate(About entity)
        {
            _aboutService.TUpdate(entity);
        }
    }
}
