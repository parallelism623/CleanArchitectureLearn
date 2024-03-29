using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Shared
{
    public class Error : IEquatable<Error>
    {
        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error NullVable = new("Error.NullValue", "The specified result value is null.");
        public Error(string code, string message) 
        {
            Code = code;
            Message = message;
        }
        public override bool Equals(object? other)
        {
            return other is Error otherError && Equals(otherError);
        }
        public static implicit operator string(Error error) => error.Code;
        public string Code { get; }
        public string Message { get; }  
        public bool Equals(Error? other)
        {
            if (other == null)
            {
                return false;
            }
            return other.Code == Code && other.Message == Message;
        }
        public override int GetHashCode() => HashCode.Combine(Code, Message);
    }
}
