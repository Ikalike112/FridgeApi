using Application.FridgeProduct.Commands.CreateFridgeProduct;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Filters.ActionFilters
{
    public class ValidateFridgeModelForCreateAttribute : IAsyncActionFilter
    {
        private readonly IFridgeDbContext _db;
        private readonly ILoggerManager _loggerManager;

        public ValidateFridgeModelForCreateAttribute(IFridgeDbContext db,
            ILoggerManager loggerManager)
        {
            _db = db;
            _loggerManager = loggerManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var fridgeDto = context.ActionArguments["createFridge"] as FridgeForCreateDto;
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
