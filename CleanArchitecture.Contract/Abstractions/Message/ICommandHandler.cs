using CleanArchitecture.Contract.Abstractions.Shared;
using MediatR;

namespace CleanArchitecture.Contract.Abstractions.Message
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> where TCommand : ICommand { }
    public interface ICommandHandler<TCommand, TRespone> : IRequestHandler<TCommand, Result<TRespone>> where TCommand : ICommand<TRespone> { }
}
