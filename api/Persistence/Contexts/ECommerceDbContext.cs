using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class ECommerceDbContext : IdentityDbContext<AppUser, AppRole, int>
{
     public ECommerceDbContext() { }
     public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

     #region Entities

     public DbSet<Product> Products { get; set; }
     public DbSet<Category> Categories { get; set; }
     public DbSet<Brand> Brands { get; set; }
     public DbSet<Color> Colors { get; set; }
     public DbSet<Size> Sizes { get; set; }
     public DbSet<Order> Orders { get; set; }
     public DbSet<Customer> Customers { get; set; }
     public DbSet<Offer> Offers { get; set; }
     public DbSet<BaseFile> BaseFiles { get; set; }
     public DbSet<ProductImageFile> ProductImageFiles { get; set; }
     public DbSet<InvoiceFile> InvoiceFiles { get; set; }
     public DbSet<Product_Order> Products_Orders { get; set; }

     #endregion

     #region OnModelCreating

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          modelBuilder.Entity<Product_Order>().HasKey(x => new { x.ProductId, x.OrderId });
          modelBuilder.Entity<Product_Order>().HasOne(m => m.Order).WithMany(am => am.Products_Orders).HasForeignKey(m => m.OrderId);
          modelBuilder.Entity<Product_Order>().HasOne(m => m.Product).WithMany(am => am.Products_Orders).HasForeignKey(m => m.ProductId);

          base.OnModelCreating(modelBuilder);
     }

     #endregion

}
