using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Config
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasData(
                new Notification() { NotificationId = 1, Type = "notif-icon notif-primary", Icon = "la la-user-plus", Description = "Yeni Bir Kullanıcı Eklendi", Status = false },
                new Notification() { NotificationId = 2, Type = "notif-icon notif-success", Icon = "la la-comment", Description = "Yorum Yapıldı", Status = false },
                new Notification() { NotificationId = 3, Type = "notif-icon notif-danger", Icon = "la la-heart", Description = "Kullanıcı Beğendi", Status = false }
                );
        }
    }
}
