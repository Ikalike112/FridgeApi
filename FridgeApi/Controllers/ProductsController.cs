using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetAllProducts;
using Domain;
using Domain.DTOs;
using Filters.ActionFilters;
using MediatR;
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
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<ActionResult<ProductsDto>> UpdateProduct(Guid id,[FromBody] ProductsDto updateProduct)
        {
            var command = new UpdateProductCommand()
            {
                ProductsDto = updateProduct,
                ProductToChange = HttpContext.Items["Product"] as Product
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
