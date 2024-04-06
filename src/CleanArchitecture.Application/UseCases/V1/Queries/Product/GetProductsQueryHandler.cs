using AutoMapper;
using CleanArchitecture.Contract.Abstractions.Message;
using CleanArchitecture.Contract.Abstractions.Shared;
using CleanArchitecture.Contract.Enumerations;
using CleanArchitecture.Contract.Services.Product;
using CleanArchitecture.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            var products = string.IsNullOrEmpty(request.SearchTerm)
                ? _productRepositoryBase.FindAll() : _productRepositoryBase.FindAll(x => x.Name.Contains(request.SearchTerm) || x.Description.Contains(request.SearchTerm));

            Expression<Func<Domain.Entities.Product, object>> keySelector = request.SortColumn?.ToLower() switch
            {
                "name" => product => product.Name,
                "price" => product => product.Price,
                "description" => product => product.Description,    
                _ => product => product.Id
            };
            products = request.SortOrder == SortOrder.Descending ? products.OrderByDescending(keySelector) : products.OrderBy(keySelector);
            var result = _mapper.Map<List<Response.ProductResponse>>(products);
            return result;
        }
    }
}
