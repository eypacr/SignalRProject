using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7199/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7199/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> BookingStatusApproved(int id)
        {

            var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7199/api/Booking/BookingStatusApproved/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				try
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = DeserializeJson<List<ResultBookingStatusApproved>>(jsonData);
					return View(values);
				}
				catch (JsonReaderException ex)
				{
					// JSON ayrıştırma hatasını logla
					System.Diagnostics.Debug.WriteLine($"JSON Parsing Error: {ex.Message}");
					// Hata sayfasına yönlendirme veya uygun bir mesaj gösterme
					TempData["ErrorMessage"] = "Veri işlenirken bir hata oluştu.";
					return RedirectToAction("Index");
				}
			}
			else
			{
				// API isteği başarısız olduğunda hata sayfasına yönlendir
				TempData["ErrorMessage"] = "Veri alırken bir sorun oluştu.";
				return RedirectToAction("Index");
			}
        }
		private T DeserializeJson<T>(string jsonData)
		{
			return JsonConvert.DeserializeObject<T>(jsonData);
		}
		public async Task<IActionResult> BookingStatusCanceled(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7199/api/Booking/BookingStatusCanceled/{id}");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetBookingStatusApproved(ResultBookingStatusApproved resultBookingStatusApproved)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Product/GetBookingStatusApproved");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingStatusApproved>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> GetBookingStatusCanceled(ResultBookingStatusApproved resultBookingStatusApproved)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Product/GetBookingStatusCanceled");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingStatusApproved>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> GetBookingStatusReceived(ResultBookingStatusApproved resultBookingStatusApproved)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Product/GetBookingStatusReceived");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingStatusApproved>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
