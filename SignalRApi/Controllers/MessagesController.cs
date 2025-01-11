using AutoMapper;
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
        private readonly IMapper _mapper;

        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList() 
        {
            var values = _messageService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMessageDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto) 
        {
            createMessageDto.Status = false;
            createMessageDto.MessageSendDate = DateTime.Now;
            var values = _mapper.Map<Message>(createMessageDto);
            _messageService.TAdd(values);
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
            return Ok(_mapper.Map<GetMessageDto>(values));
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var values=_mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(values);
            return Ok("Güncelleme İşlemi Gerçekleştirildi");
        }
    }
}
