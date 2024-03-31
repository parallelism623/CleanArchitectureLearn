using CleanArchitecture.Application.Abstractions.Message;
using CleanArchitecture.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
