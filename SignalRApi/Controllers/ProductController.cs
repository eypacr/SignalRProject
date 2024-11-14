using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var product = _productService.TGetListAll();
            if (product == null || !product.Any())
            {
                return NotFound("Ürünler bulunamadı"); // Kategoriler bulunamazsa uygun yanıt
            }

            var result = _mapper.Map<List<ResultProductDto>>(product);
            return Ok(result);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var productCount = _productService.TProductCount();
            if (productCount <= 0)
            {
                return NotFound("Herhangi bir ürün bulunamadı"); // Ürün sayısı 0 veya daha az ise uygun yanıt
            }
            return Ok(productCount);
        }


        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            var productName = _productService.TProductNameByMaxPrice();
            if (string.IsNullOrEmpty(productName))
            {
                return NotFound("Maksimum fiyata sahip bir ürün bulunamadı"); // Ürün adı yoksa uygun yanıt
            }
            return Ok(productName);
        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            var productName = _productService.TProductNameByMinPrice();
            if (string.IsNullOrEmpty(productName))
            {
                return NotFound("Minimum fiyata sahip bir ürün bulunamadı"); // Ürün adı yoksa uygun yanıt
            }
            return Ok(productName);
        }

        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {
            var productCount = _productService.TProductCountByCategoryNameHamburger();
            if (productCount <= 0)
            {
                return NotFound("Hamburger kategorisinde ürün bulunamadı"); // Ürün sayısı 0 veya daha az ise uygun yanıt
            }
            return Ok(productCount);
        }

        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            var productCount = _productService.TProductCountByCategoryNameDrink();
            if (productCount <= 0)
            {
                return NotFound("İçeçek kategorisinde ürün bulunamadı"); // Ürün sayısı 0 veya daha az ise uygun yanıt
            }
            return Ok(productCount);
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            var priceAvg = _productService.TProductPriceAvg();
            if (priceAvg <= 0)
            {
                return NotFound("Ortalama ürün fiyatı hesaplanamadı"); // Ortalama fiyat 0 veya daha az ise uygun yanıt
            }
            return Ok(priceAvg);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var products = _productService.TGetProductsWithCategories();

            if (products == null || !products.Any())
            {
                return NotFound("Ürünler bulunamadı.");
            }

            var result = _mapper.Map<List<ResultProductWithCategory>>(products);

            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kategori durumu kontrolü
            var activeCategories = _productService.TGetActiveCategories();

            if (!activeCategories.Any(c => c.CategoryId == createProductDto.CategoryId))
            {
                return BadRequest("Seçilen kategori aktif değil.");
            }

            // DTO'dan varlığa dönüşüm
            var product = _mapper.Map<Product>(createProductDto);

            // Ürünü veritabanına ekleme
            _productService.TAdd(product);
            return Ok("Ürün Bilgisi Eklendi");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz ürün Id'si"); // Geçersiz ID için uygun yanıt
            }

            var product = _productService.TGetById(id);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı"); // Ürünler bulunamadığında uygun yanıt
            }

            _productService.TDelete(product);
            return Ok("Ürün Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz ürün Id'si"); // Geçersiz ID için uygun yanıt
            }

            var value = _productService.TGetById(id);
            if (value == null)
            {
                return NotFound("Ürün bulunamadı"); // Ürün bulunamadığında uygun yanıt
            }
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }

            // Mevcut ürünü veritabanından al
            var existingProduct = _productService.TGetById(updateProductDto.ProductId);
            if (existingProduct == null)
            {
                return NotFound("Ürün bulunamadı");
            }

            // Kategori durumu kontrolü
            var activeCategories = _productService.TGetActiveCategories();

            // Eğer aktif kategoriler arasında seçilen CategoryId yoksa hata ver
            if (!activeCategories.Any(c => c.CategoryId == updateProductDto.CategoryId))
            {
                return BadRequest("Seçilen kategori aktif değil.");
            }

            // DTO'daki verileri mevcut varlığa dönüştür
            _mapper.Map(updateProductDto, existingProduct);

            // Varlığı veritabanında güncelle
            _productService.TUpdate(existingProduct);
            return Ok("Ürün Bilgisi Güncellendi");
        }


        [HttpGet("ProductAvgPriceByHamburger")]
        public IActionResult ProductAvgPriceByHamburger()
        {
            return Ok(_productService.TProductAvgPriceByHamburger());
        }
    }

}
