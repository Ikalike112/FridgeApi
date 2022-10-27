using Application.Commands.Fridges;
using Application.Contracts.Fridges;
using Application.Queries.Fridges;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;
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
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        public FridgeController(IMediator mediator, IMapper mapper, ILoggerManager loggerManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public async Task<ActionResult<FridgeDto>> GetFridges()
        {
            var query = new GetFridgesQuery();
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidateFridgeExistsAtrribute))]
        public async Task<ActionResult<FridgeDto>> GetFridgeById(Guid id)
        {
            var fridge = HttpContext.Items["Fridge"] as Fridge;
            if (fridge == null)
            {
                _loggerManager.LogInfo($"Fridge with id: {id} doesn't exist in the database");
                return new NotFoundObjectResult($"Fridge with id: {id} doesn't exist in the database");
            }
            var fridgeDto = _mapper.Map<FridgeByIdDto>(fridge);
            return Ok(fridgeDto);
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
