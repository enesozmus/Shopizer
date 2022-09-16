using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.SizeOperations.Queries;

public class GetSizesQueryHandler : IRequestHandler<GetSizesQueryRequest, IReadOnlyList<GetSizesQueryResponse>>
{
     private readonly ISizeReadRepository _sizeReadRepository;
     private readonly IMapper _mapper;

     public GetSizesQueryHandler(ISizeReadRepository SizeReadRepository, IMapper mapper)
     {
          _sizeReadRepository = SizeReadRepository;
          _mapper = mapper;
     }

     public async Task<IReadOnlyList<GetSizesQueryResponse>> Handle(GetSizesQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var sizes = await _sizeReadRepository.GetAllAsync();

          // sonucu eşleyerek gönder
          return _mapper.Map<IReadOnlyList<GetSizesQueryResponse>>(sizes);
     }
}
