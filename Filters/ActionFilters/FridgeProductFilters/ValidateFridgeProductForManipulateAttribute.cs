using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.Contracts.FridgeProducts;

namespace Filters.ActionFilters.FridgeProductFilters
{
    public class ValidateFridgeProductForManipulateAttribute : IAsyncActionFilter
    {
        private readonly IFridgeDbContext _db;
        private readonly ILoggerManager _loggerManager;

        public ValidateFridgeProductForManipulateAttribute(IFridgeDbContext db,
            ILoggerManager loggerManager)
        {
            _db = db;
            _loggerManager = loggerManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var fridgeProductDto = context.ActionArguments["fridgeProductDto"] as FridgeProductForManipulateDto;
            var fridge = await _db.Fridges.Where(f => f.Id == fridgeProductDto.FridgeId).FirstOrDefaultAsync();

            if (fridge == null)
            {
                _loggerManager.LogInfo($"Fridge with id: {fridgeProductDto.FridgeId} doesn't exist in the database");
                context.Result = new NotFoundObjectResult($"Fridge with id: {fridgeProductDto.FridgeId} doesn't exist in the database");
                return;
            }

            var product = await _db.Products.Where(product => product.Id == fridgeProductDto.ProductId).FirstOrDefaultAsync();

            if (product == null)
            {
                _loggerManager.LogInfo($"Product with id {fridgeProductDto.ProductId} doesn't exist in the database");
                context.Result = new NotFoundObjectResult($"Product with id {fridgeProductDto.ProductId} doesn't exist in the database");
                return;
            }

            if (fridgeProductDto.Quantity == null)
            {
                fridgeProductDto.Quantity = product.DefaultQuantity;
            }

            await next();
        }
    }
}
