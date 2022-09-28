using Application.Abstractions.Hubs;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductOperations.Command;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
{
     private readonly IProductWriteRepository _productWriteRepository;
     private readonly IMapper _mapper;
     private readonly IProductHubService _productHubService;

     public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper, IProductHubService productHubService)
     {
          _productWriteRepository = productWriteRepository;
          _mapper = mapper;
          _productHubService = productHubService;
     }

     public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
     {
          // eşle
          var mappedProduct = _mapper.Map<Product>(request);

          // ekle ve kaydet
          await _productWriteRepository.AddAsync(mappedProduct);
          await _productHubService.ProductAddedMessageAsync($"{ request.Name} adında bir ürün veri tabanına eklenmiştir!" );

          // sonucu gönder
          return Unit.Value;
     }
}
