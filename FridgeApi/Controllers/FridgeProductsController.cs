using Application.FridgeProduct.Commands.CreateFridgeProduct;
using Application.FridgeProduct.Commands.DeleteFridgeProduct;
using Application.FridgeProduct.Commands.UpdateFridgeProduct;
using Application.FridgeProduct.Queries.GetFridgeProducts;
using Application.FridgeProduct.Queries.GetFridgeProductsById;
using Application.FridgeProduct.StoredProcedures.SPChangeZeroQuantity;
using Domain;
using Domain.DTOs;
using Filters.ActionFilters.FridgeProductFilters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
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
        [Route("ChangeZeroQuantity")]
        [HttpGet]
        public async Task<ActionResult> CallSP()
        {
            var query = new SPChangeZeroQuantityRequest();
            var vm = _mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByFridgeId(Guid id)
        {
            var query = new GetFridgeProductsByIdQuery(id);
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetFridgeProductsQuery();
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        //[HttpGet]
        //public async Task<ActionResult> CallStoredProcedure()
        //{
        //    var query = new GetFridgeProductsFromSPQuery();
        //    var fridgeProductsForUpdate = await _mediator.Send(query);
        //    return Ok();
        //}
        /// <summary>
        /// Delete FridgeProduct from Database
        /// </summary>
        /// <param name="id">FridgeProduct Id</param>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateFridgeProductExistsAttribute))]
        public async Task<ActionResult> Delete(Guid id)
        {
            var fridgeProduct = HttpContext.Items["FridgeProduct"] as FridgeProducts;
            var query = new DeleteFridgeProductCommand(fridgeProduct);
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Add Product into fridge, if product is already in fridge, it will add the amount.
        /// If Quantity is undefined it will be set up from Product table DefaultQuantity field
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "fridgeId": "30543820-BE68-4A44-89C4-0B7713E4769D",
        ///        "productId": "75DD9A97-FA23-44EF-8F9D-62D0C424EB75",
        ///        "quantity": 3
        ///     }
        ///
        /// </remarks>
        /// <returns>Return Id if result success</returns>
        /// <response code="200">Returns the Id</response>
        [HttpPost]
        [ServiceFilter(typeof(ValidateFridgeProductForManipulateAttribute))]
        public async Task<ActionResult<Guid>> Create([FromBody] FridgeProductForManipulateDto fridgeProductDto)
        {
            var command = new CreateFridgeProductCommand(fridgeProductDto);
            var fridgeproductId = await _mediator.Send(command);
            return Ok(fridgeproductId);
        }
        //[HttpPut]
        //public async Task<ActionResult> Update([FromBody] IEnumerable<FridgeProductForManipulateDto> fridgeProductsDto)
        //{
        //    var fridgeProduct = HttpContext.Items["FridgeProduct"] as FridgeProducts;
        //    var query = new UpdateFridgeProductCommand()
        //    {
        //      //  fridgeProductDto = fridgeProductDto,
        //        fridgeProductToChange = fridgeProduct
        //    };
        //    var vm = await _mediator.Send(query);
        //    return Ok(vm);
        //}
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateFridgeProductForManipulateAttribute))]
        [ServiceFilter(typeof(ValidateFridgeProductExistsAttribute))]
        public async Task<ActionResult> Update(Guid id, [FromBody] FridgeProductForManipulateDto fridgeProductDto)
        {
            var fridgeProduct = HttpContext.Items["FridgeProduct"] as FridgeProducts;
            var query = new UpdateFridgeProductCommand()
            {
                fridgeProductDto = fridgeProductDto,
                fridgeProductToChange = fridgeProduct
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
    }
}
