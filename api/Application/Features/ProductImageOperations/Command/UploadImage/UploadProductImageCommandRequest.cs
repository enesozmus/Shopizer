using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.ProductImageOperations.Command;

public class UploadProductImageCommandRequest : IRequest<Unit>
{
     public int Id { get; set; }
     public IFormFileCollection? Images { get; set; }
}
