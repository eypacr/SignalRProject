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
    public class DiscountConfig : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasData(
                new Discount() { DiscountId = 1, Title = "Hamburger Günleri", Amount = "20", Description = "Sevdiğiniz hamburgerlerin tadını çıkarmanız için harika bir fırsat!", ImageUrl = "/feane-1.0.0/images/o1.jpg", Status = true },
                new Discount() { DiscountId = 2, Title = "Pizza Günleri", Amount = "15", Description = "Tüm pizzalarımızda %20 indirim fırsatı sizleri bekliyor", ImageUrl = "/feane-1.0.0/images/o2.jpg", Status = true }
                );
        }
    }
}
