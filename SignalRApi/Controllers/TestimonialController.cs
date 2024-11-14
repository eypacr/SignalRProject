using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestoimonialService _testoimonialService;
        private readonly IMapper _mapper;
        public TestimonialController(ITestoimonialService testoimonialService, IMapper mapper)
        {
            _testoimonialService = testoimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var testoimonial = _testoimonialService.TGetListAll();
            if (testoimonial == null || !testoimonial.Any())
            {
                return NotFound("Müşteri Yorum Bilgisi bulunamadı"); // Müşteri Yorum Bilgisi bulunamazsa uygun yanıt
            }
            var value = _mapper.Map<List<ResultTestimonialDto>>(testoimonial);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTestimonial([FromBody] CreateTestimonialDto createTestimonialDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }
            var testoimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            _testoimonialService.TAdd(testoimonial);
            return Ok("Müşteri Yorum Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testoimonialService.TGetById(id);
            if (value == null)
            {
                return NotFound("Müşteri Yorum Bilgisi Alanı Bulunamadı");
            }
            _testoimonialService.TDelete(value);
            return Ok("Müşteri Yorum Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testoimonialService.TGetById(id);
            if (value == null)
            {
                return NotFound("Müşteri Yorum Bilgisi Alanı Bulunamadı");
            }
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial([FromBody] UpdateTestimonialDto updateTestimonialDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }
            var value = _testoimonialService.TGetById(updateTestimonialDto.TestimonialId);
            if (value == null)
            {
                return NotFound("Müşteri Yorum Bilgisi Alanı Bulunamadı");
            }
            // DTO'daki verileri mevcut varlığa dönüştür
            _mapper.Map(updateTestimonialDto, value);

            // Varlığı veritabanında güncelle
            _testoimonialService.TUpdate(value);
            return Ok("Müşteri Yorum Bilgisi Güncellendi");
        }
    }
}
