using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category() { CategoryId = 1, CategoryName = "Hamburger", Status = true },
                new Category() { CategoryId = 2, CategoryName = "Pizza", Status = true },
                new Category() { CategoryId = 3, CategoryName = "Makarna", Status = true },
                 new Category() { CategoryId = 4, CategoryName = "Kızarmalar", Status = true },
                new Category() { CategoryId = 5, CategoryName = "Salata", Status = true },
                new Category() { CategoryId = 6, CategoryName = "Tatlı", Status = true },
                new Category() { CategoryId = 7, CategoryName = "İçecek", Status = true }
                );
        }
    }
}
