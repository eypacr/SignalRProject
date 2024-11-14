using AutoMapper;
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
            var aboutList = _aboutService.TGetListAll();
            if (aboutList == null || !aboutList.Any())
            {
                return NotFound("About bilgileri bulunamadı.");
            }

            var result = _mapper.Map<List<ResultAboutDto>>(aboutList);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateAbout([FromBody] CreateAboutDto createAboutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }
            var about = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(about);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            if (value == null)
            {
                return NotFound("Hakkımda Alanı Bulunamadı");
            }
            _aboutService.TDelete(value);
            return Ok("Hakkımda Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }
            var value = _aboutService.TGetById(updateAboutDto.AboutId);
            if (value == null)
            {
                return NotFound("Hakkımda Alanı Bulunamadı");
            }
            // DTO'daki verileri mevcut varlığa dönüştür
            _mapper.Map(updateAboutDto, value);

            // Varlığı veritabanında güncelle
            _aboutService.TUpdate(value);
            return Ok("Hakkımda Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            if (value == null)
            {
                return NotFound("Hakkımda Alanı Bulunamadı");
            }
            var mappedValue = _mapper.Map<GetAboutDto>(value);
            return Ok(mappedValue);
        }

    }
}
