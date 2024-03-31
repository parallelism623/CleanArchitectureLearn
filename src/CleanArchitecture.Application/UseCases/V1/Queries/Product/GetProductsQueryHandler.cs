using CleanArchitecture.Application.Abstractions.Message;
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Application.UseCases.V1.Queries.Product
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsRespone>
    {
        public Task<Result<GetProductsRespone>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
