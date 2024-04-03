using Asp.Versioning;
using CleanArchitecture.Contract.Abstractions.Shared;
using CleanArchitecture.Contract.Services.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Abstraction.Controllers.V1
{

    [ApiVersion(1)]
    public class ProductController : ApiController
    {
        public ProductController(ISender sender) : base(sender)
        {
        }
        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType(typeof(Result<IEnumerable<Response.ProductResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Products()
        {
            var result = await Sender.Send(new Query.GetProductsQuery());
            return Ok(result);
        }
    }
}
