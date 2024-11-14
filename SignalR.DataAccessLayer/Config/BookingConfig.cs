using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Config
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(
                new Booking() { BookingId = 1, Name = "Ahmet Öztürk", Phone = "12345678", Mail = "AhmetOzturk@gmail.com", PersonCount = 2, Description = "Rezervasyon Alındı" },
                new Booking() { BookingId = 2, Name = "Mehmet Yıldız", Phone = "12345678", Mail = "MehmetYildiz@gmail.com", PersonCount = 3, Description = "Rezervasyon Onaylandı" },
                new Booking() { BookingId = 3, Name = "Emine Kayalı", Phone = "12345678", Mail = "EmineKayali@gmail.com", PersonCount = 4, Description = "Rezervasyon İptal Edildi" }
                );
        }
    }
}
