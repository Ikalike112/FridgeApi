using AutoMapper;
using Domain;
using FridgeApi.AutoMapperProfile;
using FridgeApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnitTests.MoqObjects;
using Xunit;
using Filters.ActionFilters.FridgeProductFilters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Application.Contracts.FridgeProducts;
using Application.QueryHandlers.FridgeProduct;
using Application.Queries.FridgeProduct;
using Application.Services.Interfaces;
using Application.CommandHandlers.FridgeProduct;
using Application.Commands.FridgeProduct;

namespace UnitTests.Tests
{
    public class FridgeProductsControllerTests : IDisposable
    {
        private readonly ValidateFridgeProductForManipulateAttribute _validateFridgeProductForManipulateAttribute;
        private readonly Mock<ActionExecutionDelegate> _actionExecutionDelegate;
        private readonly ValidateFridgeProductExistsAttribute _validateFridgeProductExistsAttribute;
        private readonly ActionContext _actionContext;
        private readonly IMapper mapper;
        private readonly FridgeProductsController _controller;
        private readonly Mock<IMediator> Mediatr;
        private readonly FridgeDbContext _db;
        public FridgeProductsControllerTests()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);


            var loggerManagerMock = new Mock<ILoggerManager>();
            Mediatr = new Mock<IMediator>();

            _db = FridgeDbContextFactory.Create();

            var httpContext = new DefaultHttpContext();
            _controller = new FridgeProductsController(Mediatr.Object, mapper)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };
    

            _actionContext = new ActionContext(
                _controller.HttpContext,
                Mock.Of<RouteData>(),
                Mock.Of<ActionDescriptor>(),
                Mock.Of<ModelStateDictionary>()
            );

            _actionExecutionDelegate = new Mock<ActionExecutionDelegate>();

            _validateFridgeProductExistsAttribute = new ValidateFridgeProductExistsAttribute(
                _db, loggerManagerMock.Object);
            _validateFridgeProductForManipulateAttribute = new ValidateFridgeProductForManipulateAttribute(
                _db, loggerManagerMock.Object);
        }
        public void Dispose()
        {
            FridgeDbContextFactory.Destroy(_db);
        }
        [Fact]
        public async Task GetAllFridgeProductsCommandHandler_Success()
        {
            //Arrange
            var handler = new GetFridgeProductsQueryHandler(_db, mapper);

            //Act
            var fridges = await handler.Handle(
                new GetFridgeProductsQuery(), CancellationToken.None);

            //Assert
            Assert.IsType<List<FridgeProductsDto>>(fridges);
            Assert.Equal(_db.FridgeProducts.Count(), fridges.Count());
        }
        [Fact]
        public async Task ValidateFridgeProductExistsAtrribute_WithUnknownGuid_ReturnNotFoundObjectResult()
        {
            //Arrange
            var actionExecutingContext = new ActionExecutingContext(
                _actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"id", Guid.NewGuid() }
                },
                _controller
            );

            //Act
            await _validateFridgeProductExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var notFoundResult = actionExecutingContext.Result;

            //Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
        [Fact]
        public async Task ValidateFridgeProductExistsAtrribute_WithExistingGuid_ReturnRightItem()
        {
            //Arrange
            var testGuid = Guid.Parse("CF6E9D69-3EB9-4F73-AC12-25A09D016A6C");

            var actionExecutingContext = new ActionExecutingContext(
                _actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"id", testGuid }
                },
                _controller
            );

            //Act
            await _validateFridgeProductExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var fridgeProduct = _controller.HttpContext.Items["FridgeProduct"] as FridgeProducts;

            //Assert
            Assert.IsType<FridgeProducts>(fridgeProduct);
            Assert.Equal(testGuid, fridgeProduct.Id);
        }
        [Fact]
        public async Task ValidateFridgeProductDtoForManipulateAttribute_ValidObject_ReturnNull()
        {
            //Arrange
            var validFridgeProduct = new FridgeProductForManipulateDto
            {
                FridgeId = Guid.Parse("7870E84D-0F97-4196-BED7-19BD8FF40A63"),
                ProductId = Guid.Parse("C30B9AC9-BDBA-4EDC-AA9C-AD3DDA4814AE"),
                Quantity = 5
            };
            var actionExecutingContext = new ActionExecutingContext(
                _actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"fridgeProductDto", validFridgeProduct }
                },
                _controller
            );

            //Act
            await _validateFridgeProductForManipulateAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var result = actionExecutingContext.Result;

            //Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task ValidateFridgeProductDtoForManipulateAttribute_InvalidFridgeId_ReturnNotFoundObjectResult()
        {
            //Arrange
            var validFridgeProduct = new FridgeProductForManipulateDto
            {
                FridgeId = Guid.NewGuid(),
                ProductId = Guid.Parse("C30B9AC9-BDBA-4EDC-AA9C-AD3DDA4814AE"),
                Quantity = 5
            };
            var actionExecutingContext = new ActionExecutingContext(
                _actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"fridgeProductDto", validFridgeProduct }
                },
                _controller
            );

            //Act
            await _validateFridgeProductForManipulateAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var result = actionExecutingContext.Result;

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task ValidateFridgeProductDtoForManipulateAttribute_InvalidProductId_ReturnNotFoundObjectResult()
        {
            //Arrange
            var validFridgeProduct = new FridgeProductForManipulateDto
            {
                FridgeId = Guid.Parse("7870E84D-0F97-4196-BED7-19BD8FF40A63"),
                ProductId = Guid.NewGuid(),
                Quantity = 5
            };
            var actionExecutingContext = new ActionExecutingContext(
                _actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"fridgeProductDto", validFridgeProduct }
                },
                _controller
            );

            //Act
            await _validateFridgeProductForManipulateAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var result = actionExecutingContext.Result;

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task CreateFridgeProductCommandHandler_Success()
        {
            //Arange
            var handler = new CreateFridgeProductCommandHandler(_db);
            var ExistingFridgeId =  Guid.Parse("B97C170D-A6BF-4F26-8231-28D9025BF3AD");
            var ExistingProductId = Guid.Parse("C30B9AC9-BDBA-4EDC-AA9C-AD3DDA4814AE");
            var ValidQuantity = 5;
            //Act
            var fridgeProduct = new FridgeProductForManipulateDto
            {
                FridgeId = ExistingFridgeId,
                ProductId = ExistingProductId,
                Quantity = ValidQuantity
            };
            var fridgeProductId = await handler.Handle(
                new CreateFridgeProductCommand(fridgeProduct), CancellationToken.None);
            //Assert
            Assert.NotNull(
                await _db.FridgeProducts.SingleOrDefaultAsync(_fridgeProduct =>
                _fridgeProduct.Id == fridgeProductId && _fridgeProduct.FridgeId == ExistingFridgeId &&
                _fridgeProduct.ProductId == ExistingProductId && _fridgeProduct.Quantity == ValidQuantity));
        }
        [Fact]
        public async void DeleteFridgeProduct_ExistingGuid_RemovesOneItem()
        {
            //Arrange
            var existingGuid = Guid.Parse("EC994091-00A1-41F5-BF8F-6ABE3B4863A3");
            var countBeforeDelete = await _db.FridgeProducts.CountAsync();
            var handler = new DeleteFridgeProductCommandHandler(_db);

            var actionExecutingContext = new ActionExecutingContext(
                _actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"id", existingGuid }
                },
                _controller
            );
            //Act
            await _validateFridgeProductExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var result = await handler.Handle(
                new DeleteFridgeProductCommand(
                    _controller.HttpContext.Items["FridgeProduct"] as FridgeProducts), CancellationToken.None);
            //Assert
            Assert.Equal(countBeforeDelete - 1, _db.FridgeProducts.Count());
        }
        [Fact]
        public async void UpdateFridgeProduct_ValidObject_Success()
        {
            //Arange
            var handler = new UpdateFridgeProductCommandHandler(_db);
            var ExistingFridgeProductId = Guid.Parse("EC994091-00A1-41F5-BF8F-6ABE3B4863A3");
            var ExistingFridgeId = Guid.Parse("B97C170D-A6BF-4F26-8231-28D9025BF3AD");
            var ExistingProductId = Guid.Parse("C30B9AC9-BDBA-4EDC-AA9C-AD3DDA4814AE");
            var ValidQuantity = 5;

            var fridgeProductDto = new FridgeProductForManipulateDto
            {
                FridgeId = ExistingFridgeId,
                ProductId = ExistingProductId,
                Quantity = ValidQuantity
            };
            var actionExecutingContext = new ActionExecutingContext(
                _actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"id", ExistingFridgeProductId },
                    {"fridgeProductDto", fridgeProductDto},
                },
                _controller
            );
            //Act

            await _validateFridgeProductExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            await _validateFridgeProductForManipulateAttribute.OnActionExecutionAsync(actionExecutingContext,
    _actionExecutionDelegate.Object);
            var existingInDatabaseFridge = _controller.HttpContext.Items["FridgeProduct"] as FridgeProducts;
            var query = new UpdateFridgeProductCommand()
            {
                fridgeProductDto = fridgeProductDto,
                fridgeProductToChange = existingInDatabaseFridge
            };
            await handler.Handle(query, CancellationToken.None);
            //Assert
            Assert.NotNull(
                           await _db.FridgeProducts.SingleOrDefaultAsync(_fridgeProducts =>
                           _fridgeProducts.Id == ExistingFridgeProductId && _fridgeProducts.FridgeId == ExistingFridgeId &&
                           _fridgeProducts.ProductId == ExistingProductId && _fridgeProducts.Quantity == ValidQuantity));
        }
    }
}
