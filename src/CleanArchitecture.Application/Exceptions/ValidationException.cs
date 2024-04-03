using CleanArchitecture.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Exceptions
{
    public sealed class ValidationException : DomainException
    {
        public ValidationException(IReadOnlyList<ValidationError> errors) 
        : base("Validation Failure", "One or more validation errors occurred")
        {
            Errors = errors;
        }
        public IReadOnlyList<ValidationError> Errors { get; };
    }
    public record ValidationError(string PropertyName, string ErrorMessage);
}
