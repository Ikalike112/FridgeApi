using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Services.Interfaces;

namespace Filters.ActionFilters.FridgeFilters
{
    public class ValidateFridgeExistsAtrribute : IAsyncActionFilter
    {
        private readonly IFridgeDbContext _db;
        private readonly ILoggerManager _loggerManager;

        public ValidateFridgeExistsAtrribute(IFridgeDbContext db,
            ILoggerManager loggerManager)
        {
            _db = db;
            _loggerManager = loggerManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var id = (Guid)context.ActionArguments["id"];
            var fridge = await _db.Fridges.Include(f => f.FridgeModel).Where(f => f.Id == id).FirstOrDefaultAsync();

            if (fridge == null)
            {
                _loggerManager.LogInfo($"Fridge with id: {id} doesn't exist in the database");
                context.Result = new NotFoundObjectResult($"Fridge with id: {id} doesn't exist in the database");
                return;
            }
            context.HttpContext.Items.Add("Fridge", fridge);
            await next();
        }
    }
}
