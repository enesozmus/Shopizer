namespace Application.Features.ProductOperations.DTOs;

public class ProductListDto
{
     public int Id { get; set; }
     public string Name { get; set; }
     public string? Path { get; set; }
     public int Stock { get; set; }
     public float Price { get; set; }
     public string BrandName { get; set; }
     public DateTime CreatedDate { get; set; }
     public DateTime? LastModifiedDate { get; set; }
}
