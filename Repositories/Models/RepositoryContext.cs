
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace StoreApp.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product { productId = 1, productName = "Bilgisayar", productPrice = 17_000 },
                new Product { productId = 2, productName = "Telefon", productPrice = 10_000 },
                new Product { productId = 3, productName = "Konsol", productPrice = 20_000 },
                new Product { productId = 4, productName = "Şemsiye", productPrice = 15_000 },
                new Product { productId = 5, productName = "Masa", productPrice = 16_000 },
                new Product { productId = 6, productName = "Sandalye", productPrice = 18_000 }

                );
        }
    }
}
