using CleanArchitecture.Contract.Abstractions.Shared;
using MediatR;

namespace CleanArchitecture.Contract.Abstractions.Message
{
    public interface ICommand : IRequest<Result> { }
    public interface ICommand<T> : IRequest<Result<T>> { }
}
