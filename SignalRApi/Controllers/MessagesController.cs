using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList() 
        {
            return Ok(_messageService.TGetListAll());
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto) 
        {
            Message message = new Message()
            {
                NameSurname = createMessageDto.NameSurname,
                Mail = createMessageDto.Mail,
                Phone = createMessageDto.Phone,
                Subject = createMessageDto.Subject,
                MessageContent = createMessageDto.MessageContent,
                MessageSendDate = DateTime.Now,
                Status = false
            };
            _messageService.TAdd(message);
            return Ok("Ekleme İşlemi Gerçekleştirildi");

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var values=_messageService.TGetByID(id);
            _messageService.TDelete(values);
            return Ok("Silme İşlemi Gerçekleştirildi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var values = _messageService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                MessageID = updateMessageDto.MessageID,
                NameSurname = updateMessageDto.NameSurname,
                Phone = updateMessageDto.Phone,
                Mail = updateMessageDto.Mail,
                Subject = updateMessageDto.Subject,
                MessageContent = updateMessageDto.MessageContent,
                MessageSendDate = updateMessageDto.MessageSendDate,
                Status = updateMessageDto.Status
            };
            _messageService.TUpdate(message);
            return Ok("Güncelleme İşlemi Gerçekleştirildi");
        }
    }
}
