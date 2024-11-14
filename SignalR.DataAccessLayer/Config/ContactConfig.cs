using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Config
{
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(
                new Contact()
                {
                    ContactId = 1,
                    Location = "https://yandex.com.tr/harita/org/cumhuriyet_meydani_parki/79938228122/?utm_medium=mapframe&utm_source=maps",
                    Phone = "Ara +90 500 000 00 00 ",
                    Mail = "Restoran@gmail.com",
                    FooterTitle = "M&Y Restoran",
                    FooterDescription = "Lezzetli yemeklerimizi denemek veya restoranımız hakkında bilgi almak için bizimle iletişime geçmekten çekinmeyin.Siz değerli misafirlerimize en iyi hizmeti sunabilmek için her zaman buradayız.Rezervasyonlular,özel etkinlikler,menü bilgileri veya diğer talebleriniz için aşağıdak iletişim kanallarından bize ulaşabilirsiniz.",
                    OpenDays= "Çalışma Saatlerimiz",
                    OpenDaysDescription= "Sabah 10:00 Akşam 22:00",
                    OpenHours= "Haftanın 7 Günü"
                }
                );
        }
    }
}
