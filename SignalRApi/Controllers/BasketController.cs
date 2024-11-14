using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly SignalRContext context;
        public BasketController(IBasketService basketService, SignalRContext context)
        {
            _basketService = basketService;
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableId(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableId == id).Select(z =>
            new ResultBasketListWithProducts
            {
                BasketId = z.BasketId,
                Count = z.Count,
                MenuTableId = z.MenuTableId,
                Price = z.Price,
                ProductId = z.ProductId,
                TotalPrice = z.TotalPrice,
                ProductName = z.Product.ProductName,
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            // Ürünün fiyatını veritabanından çekiyoruz
            var productPrice = context.Products
                                      .Where(x => x.ProductId == createBasketDto.ProductId)
                                      .Select(y => y.Price)
                                      .FirstOrDefault();
            _basketService.TAdd(new Basket()
            {
                ProductId = createBasketDto.ProductId,
                Count = 1,
                MenuTableId = createBasketDto.MenuTableId,
                Price = productPrice,
                TotalPrice = productPrice * 1,
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            // ID'nin geçerli olup olmadığını kontrol edin
            if (id <= 0)
            {
                return BadRequest("Geçersiz ID.");
            }

            // Sepetteki ürünü getirin
            var value = _basketService.TGetById(id);

            // Ürün bulunamadıysa, 404 Not Found yanıtı döndürün
            if (value == null)
            {
                return NotFound("Sepette böyle bir ürün bulunamadı.");
            }

            // Ürünü silin
            _basketService.TDelete(value);

            // Silme işlemi başarılı olduğunda yanıt döndürün
            return Ok("Sepetteki seçilen ürün silindi.");
        }

    }
}
