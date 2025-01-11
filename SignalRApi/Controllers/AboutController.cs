using AutoMapper;
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
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(values)); //mapper kullandığımız hali
            //return Ok(values); Mapper kullanmadığımız hali
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var values=_mapper.Map<About>(createAboutDto);//Mapper kullanılmış hali yani mappersız kullandığımız halinin aynısını yapıyor tek farkı kısa kullanım

            //About about = new About()//DTO kısmındaki veriler ile about entity'si içerisindeki verileri eşleyerek dto kısmında hatayı engelledik mapper yöntemini kullanabileceğiz. Bu 1.Yöntem
            //{
            //    Title = createAboutDto.Title,
            //    Description = createAboutDto.Description,
            //    ImgUrl = createAboutDto.ImgUrl
            //};//Mapper kullanmadığımız hali

            _aboutService.TAdd(values);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return Ok("Hakkımda Kısmı Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var values=_mapper.Map<About>(updateAboutDto);


            //About about = new About
            //{
            //    AboutID = updateAboutDto.AboutID,
            //    Description = updateAboutDto.Description,
            //    ImgUrl = updateAboutDto.ImgUrl,
            //    Title = updateAboutDto.Title
            //};

            _aboutService.TUpdate(values);
            return Ok("Hakkımda Kısmı Güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            return Ok(_mapper.Map<GetAboutDto>(values));//sadece values çekmek yerine mapper yapısını kullanarak da veriyi çektik.
        }
    }
}
