using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SlidersController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var slider = _sliderService.TGetListAll();
            if (slider == null || !slider.Any())
            {
                return NotFound("Slider bulunamadı"); // Öne Çıkan Bilgisi bulunamazsa uygun yanıt
            }
            var value = _mapper.Map<List<ResultSliderDto>>(slider);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSlider([FromBody] CreateSliderDto createSliderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }
            var slider = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(slider);
            return Ok("Öne Çıkan Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz kategori Id'si"); // Geçersiz ID için uygun yanıt
            }

            var slider = _sliderService.TGetById(id);
            if (slider == null)
            {
                return NotFound("Öne Çıkan Bilgisi bulunamadı"); // Öne Çıkan Bilgisi bulunamadığında uygun yanıt
            }
            _sliderService.TDelete(slider);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz Öne Çıkan Bilgisi Id'si"); // Geçersiz ID için uygun yanıt
            }

            var slider = _sliderService.TGetById(id);
            if (slider == null)
            {
                return NotFound("Öne Çıkan Bilgisi bulunamadı"); // Öne Çıkan Bilgisi bulunamadığında uygun yanıt
            }
            var value = _sliderService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSlider([FromBody] UpdateSliderDto updateSliderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }

            // Mevcut kategoriyi veritabanından al
            var existingSlider = _sliderService.TGetById(updateSliderDto.SliderId);
            if (existingSlider == null)
            {
                return NotFound("Öne Çıkan Bilgisi bulunamadı");
            }

            // DTO'daki verileri mevcut varlığa dönüştür
            _mapper.Map(updateSliderDto, existingSlider);

            // Varlığı veritabanında güncelle
            _sliderService.TUpdate(existingSlider);

            return Ok("Öne Çıkan Alan Bilgisi Güncellendi");
        }

    }
}
