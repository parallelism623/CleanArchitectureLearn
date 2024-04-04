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
        public record CreateProductCommand(string Name, decimal Price, string Description) : ICommand;
        public record UpdateProductCommand(Guid Id, string Name, decimal Price, string Description) : ICommand;
        public record DeleteProductCommand(Guid Id) : ICommand;
    }
}
