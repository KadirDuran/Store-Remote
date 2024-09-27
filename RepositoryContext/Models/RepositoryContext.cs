using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Config;
using System.Reflection;

namespace Repositories.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product>? product { get; set; } //veritabanında ki alan adları ile aynı olmalı
        public DbSet<Category>? category { get; set; }//veritabanında ki alan adları ile aynı olmalı
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.ApplyConfiguration(new ProductConfig());
            //modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                
        }
    }
}
