using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Contract.Services.Product.Validators
{
    public class DeleteProductValidator : AbstractValidator<Command.DeleteProduct>
    {
        public DeleteProductValidator()
        {

        }
    }
}
