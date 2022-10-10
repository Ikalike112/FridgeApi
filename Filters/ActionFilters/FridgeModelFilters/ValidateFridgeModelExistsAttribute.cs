using Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Filters.ActionFilters.FridgeModelFilters
{
    public class ValidateFridgeModelExistsAttribute : IAsyncActionFilter
    {
        private readonly IFridgeDbContext _db;
        private readonly ILoggerManager _loggerManager;

        public ValidateFridgeModelExistsAttribute(IFridgeDbContext db,
            ILoggerManager loggerManager)
        {
            _db = db;
            _loggerManager = loggerManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var fridgeModelId = (Guid)context.ActionArguments["id"];
            var fridgeModel = await _db.FridgeModels.Where(p => p.Id == fridgeModelId).FirstOrDefaultAsync();

            if (fridgeModel == null)
            {
                _loggerManager.LogInfo($"FridgeModel with id: {fridgeModelId} doesn't exist in the database");
                context.Result = new NotFoundObjectResult($"FridgeModel with id: {fridgeModelId} doesn't exist in the database");
                return;
            }
            context.HttpContext.Items.Add("FridgeModel", fridgeModel);
            await next();
        }
    }
}
