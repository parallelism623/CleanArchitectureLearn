using CleanArchitecture.Application.Abstractions.Message;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.V1.Commands.Product
{
    public class CreateProductCommand : ICommand
    {
        public string Name { get; set;}
    }
}
