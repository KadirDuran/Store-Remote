using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Config
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.productId);
            builder.Property(p=>p.productName).IsRequired();
            builder.Property(p=>p.productPrice).IsRequired();


            builder.HasData(
                new Product { productId = 1, categoryId = 2, imageUrl=" /images/1.jpg", productName = "Airforce Beyaz", productPrice = 17_000 },
                new Product { productId = 2, categoryId = 2, imageUrl = "/images/2.jpg", productName = "Airforce Beyaz Siyah", productPrice = 10_000 },
                new Product { productId = 3, categoryId = 2, imageUrl = "/images/3.jpg", productName = "Airforce Pudra", productPrice = 20_000 },
                new Product { productId = 4, categoryId = 2, imageUrl = "/images/4.jpg", productName = "Airforce Siyah", productPrice = 15_000 },
                new Product { productId = 5, categoryId = 2, imageUrl = "/images/5.jpg", productName = "Airforce Sİyah Beyaz", productPrice = 16_000 },
                new Product { productId = 6, categoryId = 1, imageUrl = "/images/6.jpg", productName = "Adidas Run", productPrice = 18_000 },
                new Product { productId = 7, categoryId = 1, imageUrl = "/images/7.jpg", productName = "Adidas Samba", productPrice = 18_000 }
                );
        }
    }
}
