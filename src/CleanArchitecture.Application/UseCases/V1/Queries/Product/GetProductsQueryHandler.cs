using AutoMapper;
using CleanArchitecture.Contract.Abstractions.Message;
using CleanArchitecture.Contract.Abstractions.Shared;
using CleanArchitecture.Contract.Services.Product;
using CleanArchitecture.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.UseCases.V1.Queries.Product
{

    public sealed class GetProductsQueryHandler : IQueryHandler<Query.GetProductsQuery, List<Response.ProductResponse>>
    {
        private readonly IRepositoryBase<CleanArchitecture.Domain.Entities.Product, Guid> _productRepositoryBase;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IRepositoryBase<CleanArchitecture.Domain.Entities.Product, Guid> productRepositoryBase,
                                       IMapper mapper)
        {
            _mapper = mapper;
            _productRepositoryBase = productRepositoryBase;
        }
        public async Task<Result<List<Response.ProductResponse>>> Handle(Query.GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepositoryBase.FindAll().ToListAsync();

            var result = _mapper.Map<List<Response.ProductResponse>>(products);
            return result;
        }
    }
}
