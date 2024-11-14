using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            // Kullanıcı adının mevcut olup olmadığını kontrol et
            var existingUser = await _userManager.FindByNameAsync(registerDto.Username);
            if (existingUser != null)
            {
                // Kullanıcı adı zaten varsa hata mesajı gönder
                ModelState.AddModelError(string.Empty, "Bu kullanıcı adı zaten alınmış.");
                return View(registerDto);
            }

            var appUser = new AppUser()
            {
                Name = registerDto.Name,
                UserName = registerDto.Username,
                Surname = registerDto.Surname,
                Email = registerDto.Mail
            };

            var result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            // Başarısız kayıt işleminde hata mesajlarını göster
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(registerDto);
        }

    }
}
