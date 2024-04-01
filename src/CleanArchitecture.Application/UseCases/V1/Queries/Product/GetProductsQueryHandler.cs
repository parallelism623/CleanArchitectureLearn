using CleanArchitecture.Contract.Abstractions.Message;
using CleanArchitecture.Contract.Abstractions.Shared;
using CleanArchitecture.Contract.Services.Product;
using CleanArchitecture.Domain.Abstractions.Repositories;

namespace CleanArchitecture.Application.UseCases.V1.Queries.Product
{
    public sealed class GetProductsQueryHandler : IQueryHandler<Query.GetProductsQuery, List<Response.ProductResponse>>
    {
        private readonly IRepositoryBase<CleanArchitecture.Domain.Entities.Product, Guid> _productRepositoryBase;
        public GetProductsQueryHandler()
        public Task<Result<List<Response.ProductResponse>>> Handle(Query.GetProductsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
