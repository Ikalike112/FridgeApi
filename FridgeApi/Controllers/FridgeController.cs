using Application.Fridges.Queries.GetFridges;
using Application.Interfaces;
using AutoMapper;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            _mediator=mediator;
        }
        [HttpGet]
        public async Task<ActionResult<FridgeDto>> GetFridges()
        {
            var query = new GetFridgesQuery();
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
    }
}
