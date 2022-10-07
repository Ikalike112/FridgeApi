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
    [Route("api/fridges")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IFridgeDbContext _db;
        public FridgeController(IMediator mediator
            , IMapper mapper, IFridgeDbContext db
            , ILoggerManager logger)
        {
            _mediator=mediator;
            _mapper=mapper; 
            _db=db;
            _loggerManager=logger;
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
