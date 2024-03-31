using CleanArchitecture.Contract.Abstractions.Shared;
using MediatR;

namespace CleanArchitecture.Contract.Abstractions.Message
{
    public interface IQuery<TRespone> : IRequest<Result<TRespone>> { }
}
