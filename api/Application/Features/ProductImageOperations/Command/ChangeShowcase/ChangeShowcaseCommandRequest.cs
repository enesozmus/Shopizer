using MediatR;

namespace Application.Features.ProductImageOperations.Command;

public class ChangeShowcaseCommandRequest : IRequest<Unit>
{
     public int ImageId { get; set; }
     public int ProductId { get; set; }
}
