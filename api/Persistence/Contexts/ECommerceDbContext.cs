using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence.Contexts;

public class ECommerceDbContext : IdentityDbContext<AppUser, AppRole, int>
{
     public ECommerceDbContext() { }
     public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

     #region Entities

     public DbSet<Customer> Customers { get; set; }
     public DbSet<Category> Categories { get; set; }
     public DbSet<Brand> Brands { get; set; }
     public DbSet<Color> Colors { get; set; }
     public DbSet<Size> Sizes { get; set; }
     public DbSet<Product> Products { get; set; }
     public DbSet<BasketItem> BasketItems { get; set; }
     public DbSet<Order> Orders { get; set; }
     public DbSet<Basket> Baskets { get; set; }
     public DbSet<Offer> Offers { get; set; }
     public DbSet<BaseFile> BaseFiles { get; set; }
     public DbSet<ProductImageFile> ProductImageFiles { get; set; }
     public DbSet<InvoiceFile> InvoiceFiles { get; set; }
     public DbSet<Product_Order> Products_Orders { get; set; }

     #endregion

     #region Customized SaveChangesAsync

     public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
     {
          foreach (var entry in ChangeTracker.Entries<BaseEntity>())
          {
               switch (entry.State)
               {
                    case EntityState.Added:
                         entry.Entity.CreatedDate = DateTime.Now;

                         break;
                    case EntityState.Modified:
                         entry.Entity.LastModifiedDate = DateTime.Now;
                         break;
               }
          }
          return base.SaveChangesAsync(cancellationToken);
     }

     #endregion

     #region OnModelCreating

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          modelBuilder.Entity<Product_Order>().HasKey(x => new { x.ProductId, x.OrderId });
          modelBuilder.Entity<Product_Order>().HasOne(m => m.Order).WithMany(am => am.Products_Orders).HasForeignKey(m => m.OrderId).OnDelete(DeleteBehavior.NoAction);
          modelBuilder.Entity<Product_Order>().HasOne(m => m.Product).WithMany(am => am.Products_Orders).HasForeignKey(m => m.ProductId).OnDelete(DeleteBehavior.NoAction);

          modelBuilder.Entity<Basket>().HasOne(b => b.Order).WithOne(o => o.Basket).HasForeignKey<Order>(b => b.Id);

          modelBuilder.ApplyConfiguration(new AppUserConfiguration());
          modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
          modelBuilder.ApplyConfiguration(new CustomerConfiguration());
          modelBuilder.ApplyConfiguration(new CategoryConfiguration());
          modelBuilder.ApplyConfiguration(new BrandConfiguration());
          modelBuilder.ApplyConfiguration(new ColorConfiguration());
          modelBuilder.ApplyConfiguration(new SizeConfiguration());
          modelBuilder.ApplyConfiguration(new ProductConfiguration());
          modelBuilder.ApplyConfiguration(new BasketConfiguration());
          modelBuilder.ApplyConfiguration(new OrderConfiguration());
          modelBuilder.ApplyConfiguration(new OfferConfiguration());
          modelBuilder.ApplyConfiguration(new InvoiceFileConfiguration());

          base.OnModelCreating(modelBuilder);
     }

     #endregion

}
