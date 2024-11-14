using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Config
{
    public class MenuTableConfig : IEntityTypeConfiguration<MenuTable>
    {
        public void Configure(EntityTypeBuilder<MenuTable> builder)
        {
            builder.HasData(
                new MenuTable() { MenuTableId = 1, Name = "Bahçe 01", Status = false },
                new MenuTable() { MenuTableId = 2, Name = "Bahçe 02", Status = false },
                new MenuTable() { MenuTableId = 3, Name = "Bahçe 03", Status = false },
                new MenuTable() { MenuTableId = 4, Name = "Bahçe 04", Status = false },
                new MenuTable() { MenuTableId = 5, Name = "Bahçe 05", Status = false },
                new MenuTable() { MenuTableId = 6, Name = "Bahçe 06", Status = false },
                new MenuTable() { MenuTableId = 7, Name = "Bahçe 07", Status = false },
                new MenuTable() { MenuTableId = 8, Name = "Bahçe 08", Status = false },
                new MenuTable() { MenuTableId = 9, Name = "Bahçe 09", Status = false }
                );
        }
    }
}
