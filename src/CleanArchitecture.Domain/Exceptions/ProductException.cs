using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Exceptions
{
    public static class ProductException
    {
        public class NotFound : NotFoundException
        {
            public NotFound(Guid id) : base($"Can't find product by id: {id}") { }
        }
    }
}
