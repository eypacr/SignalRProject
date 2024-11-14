using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Config
{
    public class TestimonialConfig : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.HasData(
                new Testimonial() { TestimonialId = 1,Title="Gurme", Name = "Yeliz", Comment = "Bu restoran, özgün lezzetleri ve yaratıcı sunumlarıyla gastronomi tutkunlarının buluşma noktası. Her detay özenle düşünülmüş, mekanın atmosferi ise deneyimi tamamlıyor.", ImageUrl = "/feane-1.0.0/images/client1.jpg", Status = true },
                new Testimonial() { TestimonialId = 2,Title="Gurme", Name = "Ahmet", Comment = "Bu tabak, görsel bir şölen sunarken, her lokmada yoğun bir tat deneyimi yaşatıyor. Malzemelerin tazeliği ve dikkatle seçilmiş baharatlar, damakta unutulmaz bir iz bırakıyor. Sunumundaki zarafet ise, yemeği bir sanat eserine dönüştürüyor.", ImageUrl = "/feane-1.0.0/images/client2.jpg", Status = true }
                );
        }
    }
}
