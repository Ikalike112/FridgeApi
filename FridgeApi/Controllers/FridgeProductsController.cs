using Application.FridgeProduct.Commands.CreateFridgeProduct;
using Application.FridgeProduct.Queries.GetFridgeProductsById;
using Filters.ActionFilters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Threading.Tasks;

namespace FridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FridgeProductsController(IMediator mediator)
        {
        _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByFridgeId(Guid id)
        {
            var query = new GetFridgeProductsByIdQuery(id);
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidateFridgeProductExistsAttribute))]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFridgeProductCommand createFridgeProduct)
        {
            var fridgeproductId = await _mediator.Send(createFridgeProduct);
            return Ok(fridgeproductId);
        }
    }
}
