using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                Title = createTestimonialDto.Title,
                Name = createTestimonialDto.Name,
                Comment = createTestimonialDto.Comment,
                ImgUrl = createTestimonialDto.ImgUrl,
                Status = createTestimonialDto.Status
            });
            return Ok("Müşteri Yorum Bilgisi Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return Ok("Müşteri Yorum Bilgisi Silindi.");
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                TestimonialID=updateTestimonialDto.TestimonialID,
                Title = updateTestimonialDto.Title,
                Name = updateTestimonialDto.Name,
                Comment = updateTestimonialDto.Comment,
                ImgUrl=updateTestimonialDto.ImgUrl,
                Status = updateTestimonialDto.Status
            });
            return Ok("Müşteri Yorum Bilgisi Güncellendi.");
        }
    }
}
