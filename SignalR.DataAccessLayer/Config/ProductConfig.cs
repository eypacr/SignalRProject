using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { ProductId = 1, CategoryId = 1, ProductName = "Burger", Description = "Taze malzemelerle hazırlanan hamburgerlerimiz, her ısırıkta eşsiz bir lezzet sunuyor. Klasik ve gurme seçeneklerimizle, damak tadınıza hitap eden bir deneyim yaşamaya davetlisiniz!", Price = 350, ImageUrl = "/feane-1.0.0/images/f8.png", ProductStatus = true },
                new Product() { ProductId = 2, CategoryId = 1, ProductName = "Hamburger", Description = "Taze malzemelerle hazırlanan hamburgerlerimiz, her ısırıkta eşsiz bir lezzet sunuyor. Klasik ve gurme seçeneklerimizle, damak tadınıza hitap eden bir deneyim yaşamaya davetlisiniz!", Price = 250, ImageUrl = "/feane-1.0.0/images/f2.png", ProductStatus = true },
                new Product() { ProductId = 4, CategoryId = 3, ProductName = "Makarna", Description = "İtalya’nın klasik lezzetlerinden ilham alarak, çeşitli soslarla mükemmel uyum sağlayan makarnalarla sofralarınızı şenlendirin. Kolay hazırlanabilir ve doyurucu çeşitler, her öğün için ideal!", Price = 150, ImageUrl = "/feane-1.0.0/images/f4.png", ProductStatus = true },
                new Product() { ProductId = 6, CategoryId = 5, ProductName = "Salata", Description = "Taptaze malzemelerle hazırlanan, sağlıklı ve hafif salata çeşitleriyle sofralarınıza renk katın. Mevsim yeşillikleri ve özel soslarla her damak tadına hitap eden lezzetler burada!", Price = 70, ImageUrl = "/feane-1.0.0/images/f10.png", ProductStatus = true },
                new Product() { ProductId = 7, CategoryId = 6, ProductName = "Tatlı", Description = "En tatlı anlarınıza eşlik edecek nefis tatlı seçenekleriyle gününüzü güzelleştirin. Çikolatalı, meyveli ve geleneksel tatlarla damaklarda unutulmaz bir lezzet şöleni!", Price = 350, ImageUrl = "/feane-1.0.0/images/f11.png", ProductStatus = true },
                new Product() { ProductId = 8, CategoryId = 7, ProductName = "İçecek", Description = "Serinletici ve ferahlatıcı içeceklerle her yudumda tazelenin! Doğal meyve sularından sıcak içeceklere, her zevke uygun seçenekler sizi bekliyor.", Price = 125, ImageUrl = "/feane-1.0.0/images/f12.png", ProductStatus = true },
                new Product() { ProductId = 5, CategoryId = 4, ProductName = "Kızartma", Description = "Altın sarısı, çıtır çıtır kızartmalarla atıştırmalık keyfinizi artırın. Patates, sebze ve tavuk çeşitleriyle lezzet dolu anlar için mükemmel bir tercih!", Price = 235, ImageUrl = "/feane-1.0.0/images/f5.png", ProductStatus = true },
                new Product() { ProductId = 3, CategoryId = 2, ProductName = "Pizza", Description = "İtalyan mutfağının en sevilen lezzetlerinden biri olan pizzalar, zengin malzemeleriyle damak çatlatıyor. İnce hamur veya kalın taban seçenekleriyle herkesin favorisi olmaya aday!", Price = 335, ImageUrl = "/feane-1.0.0/images/f3.png", ProductStatus = true }
                );
        }
    }
}
