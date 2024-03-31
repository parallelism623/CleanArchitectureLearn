using CleanArchitecture.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Abstractions.Message
{
    public interface IQueryHandler<TQuery, TRespone> : IRequestHandler<TQuery, Result<TRespone>> where TQuery : IQuery<TRespone> { }
}
