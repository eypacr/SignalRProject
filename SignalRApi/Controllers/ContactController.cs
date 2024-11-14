using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var contact = _contactService.TGetListAll();
            if (contact == null || !contact.Any())
            {
                return NotFound("İletişim bulunamadı"); // Kategoriler bulunamazsa uygun yanıt
            }
            var value = _mapper.Map<List<ResultContactDto>>(contact);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }
            var contact = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(contact);
            return Ok("İletişim Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            if (value == null)
            {
                return NotFound("İletişim Alanı Bulunamadı");
            }
            _contactService.TDelete(value);
            return Ok("İletişim Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            if (value == null)
            {
                return NotFound("İletişim Alanı Bulunamadı");
            }
            var mappedValue = _mapper.Map<GetContactDto>(value);
            return Ok(mappedValue);
        }

        [HttpPut]
        public IActionResult UpdateContact([FromBody] UpdateContactDto updateContactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }
            var value = _contactService.TGetById(updateContactDto.ContactId);
            if (value == null)
            {
                return NotFound("Rezervasyon Alanı Bulunamadı");
            }
            // DTO'daki verileri mevcut varlığa dönüştür
            _mapper.Map(updateContactDto, value);

            // Varlığı veritabanında güncelle
            _contactService.TUpdate(value);
            return Ok("İletişim Bilgisi Güncellendi");
        }
    }
}
