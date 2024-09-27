using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Config
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category >
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p=>p.categoryId);
            builder.Property(p=>p.categoryName).IsRequired();   


            builder.HasData(
                new Category { categoryId = 1, categoryName = "Adidas" },
                new Category { categoryId = 2, categoryName = "Nike" }
                );
        }
    }
}
