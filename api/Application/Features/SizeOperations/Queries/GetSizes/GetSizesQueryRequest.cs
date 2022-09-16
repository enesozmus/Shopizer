using MediatR;

namespace Application.Features.SizeOperations.Queries;

public class GetSizesQueryRequest : IRequest<IReadOnlyList<GetSizesQueryResponse>> { }