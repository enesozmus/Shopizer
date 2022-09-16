using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ColorOperations.Queries;

public class GetColorsQueryHandler : IRequestHandler<GetColorsQueryRequest, IReadOnlyList<GetColorsQueryResponse>>
{
     private readonly IColorReadRepository _colorReadRepository;
     private readonly IMapper _mapper;

     public GetColorsQueryHandler(IColorReadRepository ColorReadRepository, IMapper mapper)
     {
          _colorReadRepository = ColorReadRepository;
          _mapper = mapper;
     }

     public async Task<IReadOnlyList<GetColorsQueryResponse>> Handle(GetColorsQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var colors = await _colorReadRepository.GetAllAsync();

          // sonucu eşleyerek gönder
          return _mapper.Map<IReadOnlyList<GetColorsQueryResponse>>(colors);
     }
}
