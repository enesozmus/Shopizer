namespace Domain.Entities;

public class Color : BaseEntity
{
     public string Name { get; set; }
     public ICollection<Product> Products { get; set; }
}
