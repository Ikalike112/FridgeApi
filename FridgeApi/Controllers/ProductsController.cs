using Application.Commands.Products;
using Application.Contracts.Products;
using Application.Queries.Products;
using Domain.Entities;
using Filters.ActionFilters.ProductFilters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<ProductsDto>> GetProducts()
        {
            var query = new GetAllProductsQuery();
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<ActionResult> UpdateProduct(Guid id, [FromForm] ProductForManipulateDto updateProduct)
        {
            var command = new UpdateProductCommand()
            {
                ProductsDto = updateProduct,
                ProductToChange = HttpContext.Items["Product"] as Product
            };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Guid>> CreateProduct([FromForm] ProductForManipulateDto productDto)
        {
            var command = new CreateProductCommand(productDto);
            var pruductId = await _mediator.Send(command);
            return Ok(pruductId);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<ActionResult<ProductsDto>> DeleteProduct(Guid id)
        {
            var productForDelete = HttpContext.Items["Product"] as Product;
            var command = new DeleteProductCommand(productForDelete);
            _mediator.Send(command);
            return NoContent();
        }
    }
}
