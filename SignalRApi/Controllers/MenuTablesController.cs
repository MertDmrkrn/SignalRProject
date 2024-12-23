using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {

                Name = createMenuTableDto.Name,
                Status = false
            };
            _menuTableService.TAdd(menuTable);
            return Ok("Ekleme İşlemi Gerçekleştirildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id) 
        {
            var values=_menuTableService.TGetByID(id);
            _menuTableService.TDelete(values);
            return Ok("Silme İşlemi Gerçekleştirildi");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                MenuTableID = updateMenuTableDto.MenuTableID,
                Name = updateMenuTableDto.Name,
                Status = false
            };
            _menuTableService.TUpdate(menuTable);
            return Ok("Güncelleme İşlemi Gerçekleştirildi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id) 
        {
            var values = _menuTableService.TGetByID(id);
            return Ok(values);
        }
    }
}
