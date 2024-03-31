﻿using CleanArchitecture.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Abstractions.Message
{
    public interface ICommand : IRequest<Result> { }
    public interface ICommand<T> : IRequest<Result<T>> { }
}