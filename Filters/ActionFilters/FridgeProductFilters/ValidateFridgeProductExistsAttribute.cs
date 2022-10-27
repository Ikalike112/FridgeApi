using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Services.Interfaces;

namespace Filters.ActionFilters.FridgeProductFilters
{
    public class ValidateFridgeProductExistsAttribute : IAsyncActionFilter
    {
        private readonly IFridgeDbContext _db;
        private readonly ILoggerManager _loggerManager;

        public ValidateFridgeProductExistsAttribute(IFridgeDbContext db,
            ILoggerManager loggerManager)
        {
            _db = db;
            _loggerManager = loggerManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var id = (Guid)context.ActionArguments["id"];
            var FridgeProduct = await _db.FridgeProducts.Where(f => f.Id == id).FirstOrDefaultAsync();

            if (FridgeProduct == null)
            {
                _loggerManager.LogInfo($"FridgeProduct with id: {id} doesn't exist in the database");
                context.Result = new NotFoundObjectResult($"FridgeProduct with id: {id} doesn't exist in the database");
                return;
            }
            context.HttpContext.Items.Add("FridgeProduct", FridgeProduct);
            await next();
        }
    }
}
