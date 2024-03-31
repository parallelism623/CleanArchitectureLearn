using CleanArchitecture.Contract.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanArchitecture.Contract.Services.Product
{
    public static class Command
    {
        public record CreateProduct(string Name, decimal Price, string Description) : ICommand;
        public record UpdateProduct(Guid id, string Name, decimal Price, string Description) : ICommand;
        public record DeleteProduct(Guid id) : ICommand;
    }
}
