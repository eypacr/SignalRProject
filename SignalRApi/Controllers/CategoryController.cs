using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var categories = _categoryService.TGetListAll();
            if (categories == null || !categories.Any())
            {
                return NotFound("Kategoriler bulunamadı"); // Kategoriler bulunamazsa uygun yanıt
            }

            var result = _mapper.Map<List<ResultCategoryDto>>(categories);
            return Ok(result);
        }


        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            try
            {
                var count = _categoryService.TCategoryCount();

                // Negatif değer kontrolü, olası hata durumlarını ele alır
                if (count < 0)
                {
                    return StatusCode(500, "Kategori sayısı alınırken bir hata oluştu");
                }

                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                // Hata yönetimi: loglama yapılabilir
                // Gerçek uygulamalarda hata loglama yapılmalıdır
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            try
            {
                var count = _categoryService.TActiveCategoryCount();
                if (count < 0)
                {
                    // Hata durumunda uygun bir yanıt döndür
                    return StatusCode(500, "Aktif kategori sayısı alınırken bir hata oluştu");
                }

                // Sonuç döndürme
                return Ok(new { ActiveCategoryCount = count });
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir yanıt döndür ve hata loglama yap
                // Gerçek uygulamada loglama yapılabilir
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            try
            {
                var count = _categoryService.TPassiveCategoryCount();

                // Negatif değer kontrolü, olası hata durumlarını ele alır
                if (count < 0)
                {
                    return StatusCode(500, "Pasif kategori sayısı alınırken bir hata oluştu");
                }

                return Ok(new { PassiveCategoryCount = count });
            }
            catch (Exception ex)
            {
                // Hata yönetimi: loglama yapılabilir
                // Gerçek uygulamalarda hata loglama yapılmalıdır
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }

            // DTO'dan varlığa dönüşüm
            var category = _mapper.Map<Category>(createCategoryDto);

            // Kategoriyi veritabanına ekleme
            _categoryService.TAdd(category);

            return Ok("Kategori başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz kategori Id'si"); // Geçersiz ID için uygun yanıt
            }

            var category = _categoryService.TGetById(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı"); // Kategori bulunamadığında uygun yanıt
            }

            _categoryService.TDelete(category);
            return Ok("Kategori başarıyla silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz kategori Id'si"); // Geçersiz ID için uygun yanıt
            }

            var category = _categoryService.TGetById(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı"); // Kategori bulunamadığında uygun yanıt
            }

            return Ok(category);
        }


        [HttpPut]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Geçersiz DTO için uygun yanıt
            }

            // Mevcut kategoriyi veritabanından al
            var existingCategory = _categoryService.TGetById(updateCategoryDto.CategoryId);
            if (existingCategory == null)
            {
                return NotFound("Kategori bulunamadı");
            }

            // DTO'daki verileri mevcut varlığa dönüştür
            _mapper.Map(updateCategoryDto, existingCategory);

            // Varlığı veritabanında güncelle
            _categoryService.TUpdate(existingCategory);

            return Ok("Kategori başarıyla güncellendi");
        }

    }
}
