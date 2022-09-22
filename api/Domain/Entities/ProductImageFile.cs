namespace Domain.Entities;

public class ProductImageFile : BaseFile
{
     public bool Showcase { get; set; }
     public ICollection<Product> Products { get; set; }
     //public int ProductId { get; set; }
     //public Product Product { get; set; }
}
