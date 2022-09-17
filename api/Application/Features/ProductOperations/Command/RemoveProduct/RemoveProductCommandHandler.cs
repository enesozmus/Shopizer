using Application.IRepositories;
using MediatR;

namespace Application.Features.ProductOperations.Command;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, Unit>
{
     private readonly IProductReadRepository _productReadRepository;
     private readonly IProductWriteRepository _productWriteRepository;

     public RemoveProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
     {
          _productReadRepository = productReadRepository;
          _productWriteRepository = productWriteRepository;
     }

     public async Task<Unit> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
     {
          await _productWriteRepository.RemoveAsync(await _productReadRepository.GetByIdAsync(request.Id));
          return Unit.Value;
     }
}
