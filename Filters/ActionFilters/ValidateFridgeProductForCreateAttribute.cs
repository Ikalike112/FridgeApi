using Application.FridgeProduct.Commands.CreateFridgeProduct;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace Filters.ActionFilters
{
    public class ValidateFridgeProductForCreateAttribute : IAsyncActionFilter
    {
        private readonly IFridgeDbContext _db;
        private readonly ILoggerManager _loggerManager;

        public ValidateFridgeProductForCreateAttribute(IFridgeDbContext db,
            ILoggerManager loggerManager)
        {
            _db = db;
            _loggerManager = loggerManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var command =  context.ActionArguments["createFridgeProduct"] as CreateFridgeProductCommand;
            var fridge = await _db.Fridges.Where(f => f.Id == command.FridgeId).FirstOrDefaultAsync();

            if (fridge == null)
            {
                _loggerManager.LogInfo($"Fridge with id: {command.FridgeId} doesn't exist in the database");
                context.Result = new NotFoundObjectResult($"Fridge with id: {command.FridgeId} doesn't exist in the database");
                return;
            } 

            var product = await _db.Products.Where(product => product.Id == command.ProductId).FirstOrDefaultAsync();

            if (product == null)
            {
                _loggerManager.LogInfo($"Product with id {command.ProductId} doesn't exist in the database");
                context.Result = new NotFoundObjectResult($"Product with id {command.ProductId} doesn't exist in the database");
                return;
            }
            
            if (command.Quantity == null)
            {
                command.Quantity = product.DefaultQuantity;
            }

            await next();
        }
    }
}
