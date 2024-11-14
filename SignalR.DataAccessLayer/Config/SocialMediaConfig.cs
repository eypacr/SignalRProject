using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Config
{
    public class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasData(
                new SocialMedia() { SocialMediaId = 1, Title = "Facebook", Url = "https://tr-tr.facebook.com/login/", Icon = "fa fa-facebook" },
                new SocialMedia() { SocialMediaId = 2, Title = "X", Url = "https://x.com/", Icon = "fa fa-twitter" },
                new SocialMedia() { SocialMediaId = 3, Title = "İnstagram", Url = "https://www.instagram.com/?hl=tr", Icon = "fa fa-instagram" }
                );
        }
    }
}
