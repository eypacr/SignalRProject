using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var socialMedia = _socialMediaService.TGetListAll();
            if (socialMedia == null || !socialMedia.Any())
            {
                return NotFound("Sosyal Medya Bilgisi bulunamadı"); // Sosyal Medya Bilgisi bulunamazsa uygun yanıt
            }

            var value = _mapper.Map<List<ResultSocialMediaDto>>(socialMedia);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia([FromBody] CreateSocialMediaDto createSocialMediaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }
            var social = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(social);
            return Ok("Sosyal Medya Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            if (value == null)
            {
                return NotFound("Sosyal Medya Bilgisi Alanı Bulunamadı");
            }
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            if (value == null)
            {
                return NotFound("Sosyal Medya Bilgisi Alanı Bulunamadı");
            }
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia([FromBody] UpdateSocialMediaDto updateSocialMediaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }
            var value = _socialMediaService.TGetById(updateSocialMediaDto.SocialMediaId);
            if (value == null)
            {
                return NotFound("Sosyal Medya Bilgisi Alanı Bulunamadı");
            }
            // DTO'daki verileri mevcut varlığa dönüştür
            _mapper.Map(updateSocialMediaDto, value);

            // Varlığı veritabanında güncelle
            _socialMediaService.TUpdate(value);
            return Ok("Sosyal Medya Bilgisi Güncellendi");
        }
    }
}
