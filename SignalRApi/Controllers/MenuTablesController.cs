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
            return Ok("Masa başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var values = _menuTableService.TGetById(id);
            _menuTableService.TDelete(values);
            return Ok("Masa başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                MenuTableId = updateMenuTableDto.MenuTableId,
                Name = updateMenuTableDto.Name,
                Status = updateMenuTableDto.Status
            };
            _menuTableService.TUpdate(menuTable);
            return Ok("Masa başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("MenuTableStatusFull/{id}")]
        public IActionResult MenuTableStatusFull(int id)
        {
            _menuTableService.TGetMenuTableStatusFull(id);
            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("MenuTableStatusEmpty/{id}")]
        public IActionResult MenuTableStatusEmpty(int id)
        {
            _menuTableService.TGetMenuTableStatusEmpty(id);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
