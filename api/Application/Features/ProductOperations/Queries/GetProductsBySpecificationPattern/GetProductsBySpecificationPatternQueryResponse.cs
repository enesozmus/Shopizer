namespace Application.Features.ProductOperations.Queries;

public class GetProductsBySpecificationPatternQueryResponse
{
     public int Id { get; set; }
     public string Name { get; set; }
     public int Stock { get; set; }
     public float Price { get; set; }
     public string BrandName { get; set; }
     public string ColorName { get; set; }
     public string SizeName { get; set; }
}
