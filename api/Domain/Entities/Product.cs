namespace Domain.Entities;

public class Product : BaseEntity
{
     public string Name { get; set; }
     public int Stock { get; set; }
     public float Price { get; set; }
     public bool IsOfferable { get; set; }
     public bool IsSold { get; set; }

     public int CategoryId { get; set; }
     public Category Category { get; set; }
     public int BrandId { get; set; }
     public Brand Brand { get; set; }
     public int ColorId { get; set; }
     public Color Color { get; set; }
     public int SizeId { get; set; }
     public Size Size { get; set; }
     public int AppUserId { get; set; }
     public AppUser AppUser { get; set; }


     //public ICollection<Order> Orders { get; set; }
     public ICollection<Offer> Offers { get; set; }
     public ICollection<BasketItem> BasketItems { get; set; }
     public ICollection<ProductImageFile> ProductImageFiles { get; set; }

     public List<Product_Order> Products_Orders { get; set; }
}
