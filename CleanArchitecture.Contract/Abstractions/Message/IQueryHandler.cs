using CleanArchitecture.Contract.Abstractions.Shared;
using MediatR;
namespace CleanArchitecture.Contract.Abstractions.Message
{
    public interface IQueryHandler<TQuery, TRespone> : IRequestHandler<TQuery, Result<TRespone>> where TQuery : IQuery<TRespone> { }
}
