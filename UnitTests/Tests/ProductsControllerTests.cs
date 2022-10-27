using AutoMapper;
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
using System.Threading.Tasks;
using UnitTests.MoqObjects;
using Filters.ActionFilters.ProductFilters;
using Microsoft.AspNetCore.Routing;
using System.Threading;
using Xunit;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.Tests
{
    public class ProductsControllerTests : IDisposable
    {
        private readonly ValidateProductExistsAttribute _validateProductExistsAttribute;
        private readonly Mock<ActionExecutionDelegate> _actionExecutionDelegate;
        private readonly ActionContext _actionContext;
        private readonly IMapper mapper;
        private readonly ProductsController _controller;
        private readonly Mock<IMediator> Mediatr;
        private readonly FridgeDbContext _db;
        private readonly Mock<IImageService> _imageService;
        public ProductsControllerTests()
        {
            var loggerManagerMock = new Mock<ILoggerManager>();
            Mediatr = new Mock<IMediator>();

            _db = FridgeDbContextFactory.Create();

            var httpContext = new DefaultHttpContext();
            _controller = new ProductsController(Mediatr.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };

            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            _imageService = new Mock<IImageService>();

            _actionContext = new ActionContext(
                _controller.HttpContext,
                Mock.Of<RouteData>(),
                Mock.Of<ActionDescriptor>(),
                Mock.Of<ModelStateDictionary>()
            );

            _actionExecutionDelegate = new Mock<ActionExecutionDelegate>();

            _validateProductExistsAttribute = new ValidateProductExistsAttribute(
                _db, loggerManagerMock.Object);
        }
        public void Dispose()
        {
            FridgeDbContextFactory.Destroy(_db);
        }

        [Fact]
        public async Task GetAllProductsCommandHandler_Success()
        {
            //Arrange
            var handler = new GetAllProductsQueryHandler(_db, mapper);

            //Act
            var products = await handler.Handle(
                new GetAllProductsQuery(), CancellationToken.None);

            //Assert
            Assert.IsType<List<ProductsDto>>(products);
            Assert.Equal(_db.Products.Count(), products.Count());
        }
        [Fact]
        public async Task ValidateProductExistsAtrribute_WithUnknownGuid_ReturnNotFoundObjectResult()
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
            await _validateProductExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var notFoundResult = actionExecutingContext.Result;

            //Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public async Task ValidateProductExistsAtrribute_WithExistingGuid_ReturnRightItem()
        {
            //Arrange
            var testGuid = Guid.Parse("413CE5BA-F360-4C4C-8F7E-CD26667FE5FF");

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
            await _validateProductExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var product = _controller.HttpContext.Items["Product"] as Product;

            //Assert
            Assert.IsType<Product>(product);
            Assert.Equal(testGuid, product.Id);
        }
        [Fact]
        public async Task CreateProductCommandHandler_Success()
        {
            //Arange
            var handler = new CreateProductCommandHandler(_db, mapper,_imageService.Object);
            var ProductName = "Meat";
            var defaultQuantity = 3;
            //Act
            var ProductForManipulateDto = new Domain.DTOs.ProductForManipulateDto
            {
                Name = ProductName,
                DefaultQuantity = defaultQuantity
            };
            var productId = await handler.Handle(
                new CreateProductCommand(ProductForManipulateDto), CancellationToken.None);
            //Assert
            Assert.NotNull(
                await _db.Products.SingleOrDefaultAsync(_product =>
                _product.Id == productId && _product.Name == ProductName &&
                _product.DefaultQuantity == defaultQuantity));
        }
        [Fact]
        public async Task DeleteProduct_ExistingGuid_RemovesOneItem()
        {
            //Arrange
            var existingGuid = Guid.Parse("413CE5BA-F360-4C4C-8F7E-CD26667FE5FF");
            var countBeforeDelete = await _db.Products.CountAsync();
            var handler = new DeleteProductCommandHandler(_db, _imageService.Object);

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
            await _validateProductExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var result = await handler.Handle(
                new DeleteProductCommand(
                    _controller.HttpContext.Items["Product"] as Product), CancellationToken.None);
            //Assert
            Assert.Equal(countBeforeDelete - 1, _db.Products.Count());
        }
        [Fact]
        public async Task UpdateProduct_ValidObject_Success()
        {
            //Arrange
            var existingProductGuid = Guid.Parse("A3DB9CB6-4D70-44FC-B140-969B5594A56E");
            var productDto = new ProductForManipulateDto()
            {
                Name = "Tomatoes",
                DefaultQuantity = 9
            };
            var countBeforeDelete = await _db.Products.CountAsync();
            var handler = new UpdateProductCommandHandler(_db, mapper, _imageService.Object);

            var actionExecutingContext = new ActionExecutingContext(
                _actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"id", existingProductGuid }
                },
                _controller
            );
            //Act
            await _validateProductExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var existingInDatabaseProduct = _controller.HttpContext.Items["Product"] as Product;
            var query = new UpdateProductCommand()
            {
                ProductsDto = productDto,
                ProductToChange = existingInDatabaseProduct
            };
            await handler.Handle(query, CancellationToken.None);
            //Assert
            Assert.NotNull(
                           await _db.Products.SingleOrDefaultAsync(_product =>
                           _product.Id == existingProductGuid && _product.Name == productDto.Name &&
                           _product.DefaultQuantity == productDto.DefaultQuantity));
        }
    }
}
