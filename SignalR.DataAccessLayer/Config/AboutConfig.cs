using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Config
{
    public class AboutConfig : IEntityTypeConfiguration<About>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<About> builder)
        {
            builder.HasData(
                new About() { AboutId=1,ImageUrl= "/feane-1.0.0/images/about-img.png", Title = "Biz Lezzet Ustasıyız",Description= "Biz Lezzet Ustasıyız, çünkü her tabakta kaliteyi, tutkuyu ve taze malzemeleri bir araya getiriyoruz. Müşterilerimize sadece yemek sunmuyor, unutulmaz bir lezzet deneyimi yaşatıyoruz. Geleneksel tariflerimizi modern dokunuşlarla harmanlayarak, her damağa hitap eden benzersiz lezzetler yaratıyoruz. Bizim için yemek, bir sanattır ve her öğünde bu sanatı yansıtıyoruz. Lezzet yolculuğumuza katılın ve tadı damağınızda kalacak deneyimlerin keyfini çıkarın." }
                );
        }
    }
}
