using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetAllProducts;
using Domain.DTOs;
using Domain;
using Filters.ActionFilters.ProductFilters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Application.FridgeModels.Queries.GetAllFridgeModels;
using Filters.ActionFilters.FridgeFilters;
using Filters.ActionFilters.FridgeModelFilters;
using Application.FridgeModels.Commands.UpdateFridgeModel;
using Application.FridgeModels.Commands.CreateFridgeModel;
using Application.Fridges.Commands.DeleteFridge;
using Application.FridgeModels.Commands.DeleteFridgeModel;

namespace FridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeModelController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FridgeModelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<FridgeModelDto>> GetAllFridgeModels()
        {
            var query = new GetAllFridgeModelsQuery();
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateFridgeModelExistsAttribute))]
        public async Task<ActionResult> UpdateFridgeModel(Guid id, [FromBody] FridgeModelForManipulateDto fridgeModelDto)
        {
            var command = new UpdateFridgeModelCommand()
            {
                FridgeModelDto = fridgeModelDto,
                FridgeModelToChange = HttpContext.Items["FridgeModel"] as FridgeModel
            };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateFridgeModel([FromBody] FridgeModelForManipulateDto fridgeModelDto)
        {
            var command = new CreateFridgeModelCommand(fridgeModelDto);
            var fridgeModelId = await _mediator.Send(command);
            return Ok(fridgeModelId);
        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateFridgeModelExistsAttribute))]
        public async Task<ActionResult<ProductsDto>> DeleteFridgeModel(Guid id)
        {
            var productForDelete = HttpContext.Items["FridgeModel"] as FridgeModel;
            var command = new DeleteFridgeModelCommand(productForDelete);
            _mediator.Send(command);
            return NoContent();
        }
    }
}
