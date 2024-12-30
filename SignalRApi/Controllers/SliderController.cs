using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

		public SliderController(ISliderService sliderService, IMapper mapper)
		{
			_sliderService = sliderService;
			_mapper = mapper;
		}

		[HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            _sliderService.TAdd(new Slider()
            {
                Title1 = createSliderDto.Title1,
                Descripton1 = createSliderDto.Descripton1,
                Title2 = createSliderDto.Title2,
                Descripton2 = createSliderDto.Descripton2,
                Title3 = createSliderDto.Title3,
                Descripton3 = createSliderDto.Descripton3
            });
            return Ok("Öne Çıkan Alan Bilgisi Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var values = _sliderService.TGetByID(id);
            _sliderService.TDelete(values);
            return Ok("Öne Çıkan Alan Bilgisi Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var values = _sliderService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _sliderService.TUpdate(new Slider()
            {
                SliderID = updateSliderDto.SliderID,
                Title1 = updateSliderDto.Title1,
                Descripton1 = updateSliderDto.Descripton1,
                Title2 = updateSliderDto.Title2,
                Descripton2 = updateSliderDto.Descripton2,
                Title3 = updateSliderDto.Title3,
                Descripton3 = updateSliderDto.Descripton3

            });
            return Ok("Öne Çıkan Alan Bilgisi Güncellendi.");
        }
    }
}
