using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Contract.Abstractions.Shared
{
    public class Result
    {
        protected internal Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
            {
                throw new InvalidOperationException();
            }
            if (!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException();
            }
            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public static Result Success() => new(true,  Error.None);
        public static Result Failure(Error error) => new(false, error);

        public static Result<T>Success<T>(T result) => new(result, true, Error.None);
        public static Result<T> Failure<T>(Error error) => new(default, false, error);

        public static Result<T> Create<T>(T result) => result is not null ? Success(result) : Failure<T>(Error.NullVable);
    }
    public class Result<T> : Result
    {
        
        protected internal Result(T value, bool IsSuccess, Error Error) : base(IsSuccess, Error)
        {
            _value = value;
        }
        public T Value => IsSuccess ? _value! : throw new InvalidOperationException("The value of a failure result can not be accessed.");
        private readonly T _value;
        public static implicit operator Result<T>(T result) => Create(result);  
    }
}
