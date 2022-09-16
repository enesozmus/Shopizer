using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.BrandOperations.Queries;

public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQueryRequest, IReadOnlyList<GetBrandsQueryResponse>>
{
     private readonly IBrandReadRepository _brandReadRepository;
     private readonly IMapper _mapper;

     public GetBrandsQueryHandler(IBrandReadRepository BrandReadRepository, IMapper mapper)
     {
          _brandReadRepository = BrandReadRepository;
          _mapper = mapper;
     }

     public async Task<IReadOnlyList<GetBrandsQueryResponse>> Handle(GetBrandsQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var brands = await _brandReadRepository.GetAllAsync();

          // sonucu eşleyerek gönder
          return _mapper.Map<IReadOnlyList<GetBrandsQueryResponse>>(brands);
     }
}
