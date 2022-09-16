using MediatR;

namespace Application.Features.ColorOperations.Queries;

public class GetColorsQueryRequest : IRequest<IReadOnlyList<GetColorsQueryResponse>> { }