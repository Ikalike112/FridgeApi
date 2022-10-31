using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Filters.ActionFilters.FridgeModelFilters;
using Microsoft.AspNetCore.Authorization;
using Application.Contracts.FridgeModels;
using Application.Queries.FridgeModels;
using Application.Commands.FridgeModels;
using Application.Contracts.Fridges;
using Domain.Entities;

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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Guid>> CreateFridgeModel([FromBody] FridgeModelForManipulateDto fridgeModelDto)
        {
            var command = new CreateFridgeModelCommand(fridgeModelDto);
            var fridgeModelId = await _mediator.Send(command);
            return Ok(fridgeModelId);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateFridgeModelExistsAttribute))]
        public async Task<ActionResult> DeleteFridgeModel(Guid id)
        {
            var productForDelete = HttpContext.Items["FridgeModel"] as FridgeModel;
            var command = new DeleteFridgeModelCommand(productForDelete);
            _mediator.Send(command);
            return NoContent();
        }
    }
}
