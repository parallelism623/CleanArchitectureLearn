using CleanArchitecture.Contract.Abstractions.Message;

namespace CleanArchitecture.Application.UseCases.V1.Commands.Product
{
    public class CreateProductCommand : ICommand
    {
        public string Name { get; set;}
    }
}
