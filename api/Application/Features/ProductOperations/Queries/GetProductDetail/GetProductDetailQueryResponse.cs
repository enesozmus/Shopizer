namespace Application.Features.ProductOperations.Queries;

public class GetProductDetailQueryResponse
{
     public int Id { get; set; }
     public string Name { get; set; }
     public int Stock { get; set; }
     public float Price { get; set; }
     public bool IsOfferable { get; set; }
     public bool IsSold { get; set; }
     public string CategoryName { get; set; }
     public string UserName { get; set; }
     public string BrandName { get; set; }
     public string ColorName { get; set; }
     public string SizeName { get; set; }
     public DateTime CreatedDate { get; set; }
     public DateTime? LastModifiedDate { get; set; }
}
