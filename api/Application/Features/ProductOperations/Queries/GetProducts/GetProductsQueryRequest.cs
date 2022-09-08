using MediatR;

namespace Application.Features.ProductOperations.Queries;

public class GetProductsQueryRequest : IRequest<IReadOnlyList<GetProductsQueryResponse>> { }