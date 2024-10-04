using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactService _contactService;

        public ContactManager(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void TAdd(Contact entity)
        {
            _contactService.TAdd(entity);
        }

        public void TDelete(Contact entity)
        {
            _contactService.TDelete(entity);
        }

        public Contact TGetByID(int id)
        {
            return _contactService.TGetByID(id);
        }

        public List<Contact> TGetListAll()
        {
            return _contactService.TGetListAll();
        }

        public void TUpdate(Contact entity)
        {
            _contactService.TUpdate(entity);
        }
    }
}
