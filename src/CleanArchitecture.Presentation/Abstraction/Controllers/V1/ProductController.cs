using Asp.Versioning;
using CleanArchitecture.Contract.Abstractions.Shared;
using CleanArchitecture.Contract.Services.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CleanArchitecture.Contract.Services.Product.Command;

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
        [HttpPut("{productId}")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Products(Guid productId, [FromBody] Command.UpdateProductCommand updateProduct)
        {
            var updateProductCommand = new Command.UpdateProductCommand(productId, updateProduct.Name, updateProduct.Price, updateProduct.Description);
            var result = await Sender.Send(updateProductCommand);
            return Ok(result);
        }
    }
}
