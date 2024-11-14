using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly SignalRContext context;
        private readonly IValidator<CreateBookingDto> _validator;
        public BookingController(IBookingService bookingService, SignalRContext context, IValidator<CreateBookingDto> validator)
        {
            _bookingService = bookingService;
            this.context = context;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var validationResult = _validator.Validate(createBookingDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            Booking booking = new Booking()
            {
                Description = "Rezervasyon Alındı",
                Mail = createBookingDto.Mail,
                Name = createBookingDto.Name,
                Date = createBookingDto.Date,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone

            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon Yapıldı.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok("Your reservation is canceled");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                Description = updateBookingDto.Description,
                BookingId = updateBookingDto.BookingId,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                Date = updateBookingDto.Date,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone
            };
            _bookingService.TUpdate(booking);
            return Ok("Your reservaiton is updated");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.BookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
        [HttpGet("BookingStatusCanceled/{id}")]
        public IActionResult BookingStatusCanceled(int id)
        {
            _bookingService.BookingStatusCanceled(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
        [HttpGet("GetBookingStatusApproved")]
        public IActionResult GetBookingStatusApproved()
        {
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon Onaylandı").ToList();
            return Ok(values.ToList());
        }
        [HttpGet("GetBookingStatusCanceled")]
        public IActionResult GetBookingStatusCanceled()
        {
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon İptal Edildi").ToList();
            return Ok(values.ToList());
        }
        [HttpGet("GetBookingStatusReceived")]
        public IActionResult GetBookingStatusReceived()
        {
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon Alındı").ToList();
            return Ok(values.ToList());
        }
        [HttpGet("BookingStatusApprovedCount")]
        public IActionResult BookingStatusApprovedCount()
        {
            return Ok(_bookingService.TBookingStatusApprovedCount());
        }
    }
}
