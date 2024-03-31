using CleanArchitecture.Contract.Abstractions.Message;
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
        public record GetProduct() : IQuery<List<ProductRespone>>;
        public record GetProductById(Guid id) : IQuery<ProductRespone>;
    }
}
