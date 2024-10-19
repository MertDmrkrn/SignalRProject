using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(new Feature()
            {
                Title1 = createFeatureDto.Title1,
                Descripton1 = createFeatureDto.Descripton1,
                Title2 = createFeatureDto.Title2,
                Descripton2 = createFeatureDto.Descripton2,
                Title3 = createFeatureDto.Title3,
                Descripton3 = createFeatureDto.Descripton3
            });
            return Ok("Öne Çıkan Alan Bilgisi Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            _featureService.TDelete(values);
            return Ok("Öne Çıkan Alan Bilgisi Silindi.");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureID = updateFeatureDto.FeatureID,
                Title1 = updateFeatureDto.Title1,
                Descripton1 = updateFeatureDto.Descripton1,
                Title2 = updateFeatureDto.Title2,
                Descripton2 = updateFeatureDto.Descripton2,
                Title3 = updateFeatureDto.Title3,
                Descripton3 = updateFeatureDto.Descripton3

            });
            return Ok("Öne Çıkan Alan Bilgisi Güncellendi.");
        }
    }
}
