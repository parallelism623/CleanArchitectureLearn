using CleanArchitecture.Contract.Abstractions.Shared;
using CleanArchitecture.Contract.Services.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.Abstraction
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected readonly ISender Sender;
        protected ApiController(ISender sender)
        {
            Sender = sender;
        }
    }
}
