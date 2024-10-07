using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()//DTO kısmındaki veriler ile about entity'si içerisindeki verileri eşleyerek dto kısmında hatayı engelledik mapper yöntemini kullanabileceğiz. Bu 1.Yöntem
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImgUrl = createAboutDto.ImgUrl
            };

            _aboutService.TAdd(about);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return Ok("Hakkımda Kısmı Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About
            {
                AboutID=updateAboutDto.AboutID,
                Description = updateAboutDto.Description,
                ImgUrl = updateAboutDto.ImgUrl,
                Title = updateAboutDto.Title
            };

            _aboutService.TUpdate(about);
            return Ok("Hakkımda Kısmı Güncellendi.");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            return Ok(values);
        }
    }
}
