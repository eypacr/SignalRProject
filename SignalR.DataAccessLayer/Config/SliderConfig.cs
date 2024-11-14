using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Config
{
    public class SliderConfig : IEntityTypeConfiguration<Slider>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Slider> builder)
        {
            builder.HasData(
                new Slider()
                {
                    SliderId = 1,
                    Title1 = "Lezetli Makarnalar",
                    Title2 = "Uzak Doğu Mutfağı",
                    Title3 = "Meksika Mutfağı",
                    Description1 = "Taze ve özenle hazırlanmış lezzetli makarnalarımız, zengin sos seçenekleriyle birleşerek her lokmada unutulmaz bir deneyim sunuyor. İster klasik ister yaratıcı tariflerimizle damak tadınıza hitap eden makarnalarımızı mutlaka denemelisiniz!",
                    Description2 = "Zengin aromalar ve taze malzemelerle hazırlanan Uzak Doğu mutfağı, eşsiz lezzetleriyle damaklarda iz bırakıyor. Sushi'den ramen'e, dim sum'dan curry'ye kadar geniş bir yelpazeye sahip bu mutfak, gastronomi tutkunları için keşfedilmeyi bekliyor!",
                    Description3 = "Renkli ve lezzet dolu yemekleriyle tanınır; taze malzemeler ve baharatlarla hazırlanan harika tarifler sunar.\r\nTacos, enchiladas ve nachos gibi ikonik lezzetler, her lokmada benzersiz bir tat deneyimi yaşatır.\r\nGeleneksel tarifler ve modern dokunuşlarla, bu mutfak her damak zevkine hitap eden bir fiesta sunuyor!"
                }
                );
        }
    }
}
