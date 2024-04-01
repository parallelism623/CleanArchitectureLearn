using CleanArchitecture.Contract.Abstractions.Message;
using CleanArchitecture.Contract.Abstractions.Shared;

namespace CleanArchitecture.Application.UseCases.V1.Commands.Product
{
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        public Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
