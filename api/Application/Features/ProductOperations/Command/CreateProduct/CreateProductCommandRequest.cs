using MediatR;

namespace Application.Features.ProductOperations.Command;

public class CreateProductCommandRequest : IRequest<Unit>
{
     public string Name { get; set; }
     public int Stock { get; set; }
     public float Price { get; set; }
     public bool IsOfferable { get; set; }
     public bool IsSold { get; set; }
     public int CategoryId { get; set; }
     public int BrandId { get; set; }
     public int ColorId { get; set; }
     public int SizeId { get; set; }
     public int AppUserId { get; set; }
}