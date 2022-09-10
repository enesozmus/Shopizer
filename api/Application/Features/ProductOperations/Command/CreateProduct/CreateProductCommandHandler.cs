using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductOperations.Command;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
{
     private readonly IProductWriteRepository _productWriteRepository;
     private readonly IMapper _mapper;

     public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
     {
          _productWriteRepository = productWriteRepository;
          _mapper = mapper;
     }

     public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
     {
          // eşle
          var mappedProduct = _mapper.Map<Product>(request);

          // ekle ve kaydet
          await _productWriteRepository.AddAsync(mappedProduct);

          // sonucu gönder
          return Unit.Value;
     }
}
