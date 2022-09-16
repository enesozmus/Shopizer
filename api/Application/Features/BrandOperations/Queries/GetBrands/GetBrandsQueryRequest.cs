using MediatR;

namespace Application.Features.BrandOperations.Queries;

public class GetBrandsQueryRequest : IRequest<IReadOnlyList<GetBrandsQueryResponse>> { }