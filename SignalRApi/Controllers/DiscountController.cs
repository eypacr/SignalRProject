using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var discount = _discountService.TGetListAll();
            if (discount == null || !discount.Any())
            {
                return NotFound("İndirim bulunamadı"); // Kategoriler bulunamazsa uygun yanıt
            }
            var value = _mapper.Map<List<ResultDiscountDto>>(discount);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDiscount([FromBody] CreateDiscountDto createDiscountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }
            var value = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(value);
            return Ok("İndirim Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            if (value == null)
            {
                return NotFound("İndirim Alanı Bulunamadı");
            }

            _discountService.TDelete(value);
            return Ok("İndirim Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            if (value == null)
            {
                return NotFound("İndirim Alanı Bulunamadı");
            }
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }
            var value = _discountService.TGetById(updateDiscountDto.DiscountId);
            if (value == null)
            {
                return NotFound("İndirim Alanı Bulunamadı");
            }
            // DTO'daki verileri mevcut varlığa dönüştür
            _mapper.Map(updateDiscountDto, value);

            // Varlığı veritabanında güncelle
            _discountService.TUpdate(value);
            return Ok("İndirim Bilgisi Güncellendi");
        }

        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);
            return Ok("Ürün indirimi aktif hale getirildi");
        }

        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);
            return Ok("Ürün indirimi pasif hale getirildi");
        }
    }
}
