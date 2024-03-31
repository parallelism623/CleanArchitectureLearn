﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Contract.Services.Product.Validators
{
    public class UpdateProductValidator : AbstractValidator<Command.UpdateProduct>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
