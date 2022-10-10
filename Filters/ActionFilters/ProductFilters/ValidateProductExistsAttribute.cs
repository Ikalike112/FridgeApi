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

namespace Filters.ActionFilters.ProductFilters
{
    public class ValidateProductExistsAttribute : IAsyncActionFilter
    {
        private readonly IFridgeDbContext _db;
        private readonly ILoggerManager _loggerManager;

        public ValidateProductExistsAttribute(IFridgeDbContext db,
            ILoggerManager loggerManager)
        {
            _db = db;
            _loggerManager = loggerManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var productId = (Guid)context.ActionArguments["id"];
            var product = await _db.Products.Where(p => p.Id == productId).FirstOrDefaultAsync();

            if (product == null)
            {
                _loggerManager.LogInfo($"Product with id: {productId} doesn't exist in the database");
                context.Result = new NotFoundObjectResult($"Product with id: {productId} doesn't exist in the database");
                return;
            }
            context.HttpContext.Items.Add("Product", product);
            await next();
        }
    }
}
