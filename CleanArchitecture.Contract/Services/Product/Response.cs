using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Contract.Services.Product
{
    public static class Response
    {
        public record ProductResponse(Guid id, string Name, decimal Price, string Description);
    }
}
