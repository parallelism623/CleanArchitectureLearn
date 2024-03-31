using CleanArchitecture.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Abstractions.Message
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> where TCommand : ICommand { }
    public interface ICommandHandler<TCommand, TRespone> : IRequestHandler<TCommand, Result<TRespone>> where TCommand : ICommand<TRespone> { }
}
