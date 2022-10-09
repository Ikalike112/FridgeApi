
using Application.FridgeProduct.Commands.DeleteFridgeProduct;
using Application.Fridges.Commands.CreateFridge;
using Application.Fridges.Commands.DeleteFridge;
using Application.Fridges.Commands.UpdateFridge;
using Application.Fridges.Queries.GetFridges;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.DTOs;
using Filters.ActionFilters.FridgeFilters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FridgeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<FridgeDto>> GetFridges()
        {
            var query = new GetFridgesQuery();
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidateFridgeModelForManipulateFridgeAttribute))]
        public async Task<ActionResult<Guid>> CreateFridge([FromBody] FridgeForCreateDto fridgeDto)
        {
            var command = new CreateFridgeCommand(fridgeDto);
            var fridgeproductId = await _mediator.Send(command);
            return Ok(fridgeproductId);
        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateFridgeExistsAtrribute))]
        public async Task<ActionResult> DeleteFridge(Guid id)
        {
            var fridge = HttpContext.Items["Fridge"] as Fridge;
            var query = new DeleteFridgeCommand(fridge);
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateFridgeModelForManipulateFridgeAttribute))]
        [ServiceFilter(typeof(ValidateFridgeExistsAtrribute))]
        public async Task<ActionResult> UpdateFridge(Guid id, [FromBody] FridgeForManipulateDto fridgeDto)
        {
            var fridge = HttpContext.Items["Fridge"] as Fridge;
            var query = new UpdateFridgeCommand()
            {
                FridgeDto = fridgeDto,
                FridgeToChange = fridge
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
    }
}
