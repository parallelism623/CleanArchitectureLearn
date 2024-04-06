using CleanArchitecture.Contract.Abstractions.Message;
using CleanArchitecture.Contract.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CleanArchitecture.Contract.Services.Product.Response;

namespace CleanArchitecture.Contract.Services.Product
{
    public static class Query
    {
        public record GetProductsQuery(string? SearchTerm, string? SortColumn, SortOrder? SortOrder) : IQuery<List<ProductResponse>>;
        public record GetProductById(Guid id) : IQuery<ProductResponse>;
    }
}
