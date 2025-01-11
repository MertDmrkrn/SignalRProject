using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetListAll();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountWithStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationsByFalse")]
        public IActionResult GetAllNotificationsByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {

            createNotificationDto.Status=false;
            createNotificationDto.Date=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var values = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(values);
            return Ok("Ekleme İşlemi Gerçekleştirildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var values = _notificationService.TGetByID(id);
            _notificationService.TDelete(values);
            return Ok("Silme İşlemi Gerçekleştirildi.");
        }
        
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var values = _notificationService.TGetByID(id);
            return Ok(_mapper.Map<GetNotificationDto>(values));
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var values=_mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(values);
            return Ok("Güncelleme İşlemi Gerçekleştirildi");
        }

        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme Yapıldı");
        }

    }
}
