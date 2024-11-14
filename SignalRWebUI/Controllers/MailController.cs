using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateMailDto createMailDto)
        {
            var mimeMessage = new MimeMessage();

            // Gönderen adresi
            var mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "Eyyupacar98@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            // Alıcı adresi
            var mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            // Mesaj içeriği
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = createMailDto.Body
            };
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            // Konu
            mimeMessage.Subject = createMailDto.Subject;

            // SMTP İstemcisi
            using (var smtpClient = new SmtpClient())
            {
                // Sertifika doğrulama işlemini devre dışı bırakma (geliştirme ortamı için)
                smtpClient.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                try
                {
                    // Bağlantı ve kimlik doğrulama
                    await smtpClient.ConnectAsync("smtp.gmail.com", 587, false);
                    await smtpClient.AuthenticateAsync("Eyyupacar98@gmail.com", "pibqohmgvwrcywdj");

                    // Mesajı gönderme
                    await smtpClient.SendAsync(mimeMessage);
                }
                catch (Exception ex)
                {
                    // Hata yönetimi
                    ModelState.AddModelError("", "Mail gönderme işlemi sırasında bir hata oluştu: " + ex.Message);
                    return View();
                }
                finally
                {
                    // Bağlantıyı kesme
                    await smtpClient.DisconnectAsync(true);
                }
            }

            return RedirectToAction("Index", "Category");
        }
    }
}
