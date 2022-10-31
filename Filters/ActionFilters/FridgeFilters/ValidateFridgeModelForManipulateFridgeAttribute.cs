using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Services.Interfaces;
using Application.Contracts.Fridges;

namespace Filters.ActionFilters.FridgeFilters
{
    public class ValidateFridgeModelForManipulateFridgeAttribute : IAsyncActionFilter
    {
        private readonly IFridgeDbContext _db;
        private readonly ILoggerManager _loggerManager;

        public ValidateFridgeModelForManipulateFridgeAttribute(IFridgeDbContext db,
            ILoggerManager loggerManager)
        {
            _db = db;
            _loggerManager = loggerManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var fridgeDto = context.ActionArguments["fridgeDto"] as FridgeForManipulateDto;
            var fridgeModel = await _db.FridgeModels.Where(f => f.Id == fridgeDto.FridgeModelId).FirstOrDefaultAsync();

            if (fridgeModel == null)
            {
                _loggerManager.LogInfo($"FridgeModel with id: {fridgeDto.FridgeModelId} doesn't exist in the database");
                context.Result = new NotFoundObjectResult($"FridgeModel with id: {fridgeDto.FridgeModelId} doesn't exist in the database");
                return;
            }

            await next();
        }
    }
}
 