using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BookingService : IBookingService
    {
        private readonly IBookingService _bookingService;

        public BookingService(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public void TAdd(Booking entity)
        {
            _bookingService.TAdd(entity);
        }

        public void TDelete(Booking entity)
        {
            _bookingService.TDelete(entity);
        }

        public Booking TGetByID(int id)
        {
            return _bookingService.TGetByID(id);
        }

        public List<Booking> TGetListAll()
        {
            return _bookingService.TGetListAll();
        }

        public void TUpdate(Booking entity)
        {
            _bookingService.TUpdate(entity);
        }
    }
}
