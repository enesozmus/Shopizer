namespace Domain.Entities;

public class Size : BaseEntity
{
     public string Name { get; set; }
     public ICollection<Product> Products { get; set; }
}
