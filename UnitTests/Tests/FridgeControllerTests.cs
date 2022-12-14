using AutoMapper;
using Domain.Entities;
using Filters.ActionFilters.FridgeFilters;
using FridgeApi.AutoMapperProfile;
using FridgeApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnitTests.MoqObjects;
using Xunit;

namespace UnitTests.Tests
{
    public class FridgeControllerTests : IDisposable
    {
        private readonly ValidateFridgeModelForManipulateFridgeAttribute _validateFridgeModelForManipulateFridgeAttribute;
        private readonly Mock<ActionExecutionDelegate> _actionExecutionDelegate;
        private readonly ValidateFridgeExistsAtrribute _validateFridgeExistsAtrribute;
        private readonly ActionContext _actionContext;
        private readonly IMapper mapper;   
        private readonly FridgeController _controller;
        private readonly Mock<IMediator> Mediatr;
        private readonly FridgeDbContext _db;
        public FridgeControllerTests()
        {
            var loggerManagerMock = new Mock<ILoggerManager>();
            Mediatr = new Mock<IMediator>();

            _db = FridgeDbContextFactory.Create();

            var httpContext = new DefaultHttpContext();
            _controller = new FridgeController(Mediatr.Object, mapper, loggerManagerMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };

            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            _actionContext = new ActionContext(
                _controller.HttpContext,
                Mock.Of<RouteData>(),
                Mock.Of<ActionDescriptor>(),
                Mock.Of<ModelStateDictionary>()
            );

            _actionExecutionDelegate = new Mock<ActionExecutionDelegate>();

            _validateFridgeExistsAtrribute = new ValidateFridgeExistsAtrribute(
                _db, loggerManagerMock.Object);
            _validateFridgeModelForManipulateFridgeAttribute = new ValidateFridgeModelForManipulateFridgeAttribute(
                _db, loggerManagerMock.Object);
        }
        public void Dispose()
        {
            FridgeDbContextFactory.Destroy(_db);
        }
        [Fact]
        public async Task GetAllFridgesCommandHandler_Success()
        {
            //Arrange
            var handler = new GetFridgesQueryHandler(_db, mapper);

            //Act
            var fridges = await handler.Handle(
                new GetFridgesQuery(),CancellationToken.None);

            //Assert
            Assert.IsType<List<FridgeDto>>(fridges);
            Assert.Equal(_db.Fridges.Count(), fridges.Count());
        }
        [Fact]
        public async Task ValidateFridgeExistsAtrribute_WithUnknownGuid_ReturnNotFoundObjectResult()
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
            await _validateFridgeExistsAtrribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var notFoundResult = actionExecutingContext.Result;

            //Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
        [Fact]
        public async Task ValidateFridgeExistsAtrribute_WithExistingGuid_ReturnRightItem()
        {
            //Arrange
            var testGuid = Guid.Parse("557D35EF-AB80-4E17-A96C-2B65CF3DD7BF");
            
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
            await _validateFridgeExistsAtrribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var fridge = _controller.HttpContext.Items["Fridge"] as Fridge;

            //Assert
            Assert.IsType<Fridge>(fridge);
            Assert.Equal(testGuid,fridge.Id);
        }
        [Fact]
        public async Task ValidateFridgeModelForManipulateFridgeAttribute_ValidObject_ReturnNull()
        {
            //Arrange
            var validFridge = new FridgeForManipulateDto
            {
                Name = "Atlanto",
                OwnerName = "James",
                FridgeModelId = Guid.Parse("B0463F44-AF0C-434F-9667-C3BF6C9F8A93")
            };
            var actionExecutingContext = new ActionExecutingContext(
                _actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"fridgeDto", validFridge }
                },
                _controller
            );

            //Act
            await _validateFridgeModelForManipulateFridgeAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var result = actionExecutingContext.Result;

            //Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task ValidateFridgeModelForManipulateFridgeAttribute_InvalidObject_ReturnNotFoundObjectResult()
        {
            //Arrange
            var validFridge = new FridgeForManipulateDto
            {
                Name = "Atlanto",
                OwnerName = "James",
                FridgeModelId = Guid.NewGuid()
            };
            var actionExecutingContext = new ActionExecutingContext(
                _actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"fridgeDto", validFridge }
                },
                _controller
            );

            //Act
            await _validateFridgeModelForManipulateFridgeAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var result = actionExecutingContext.Result;

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);

        }
        [Fact]
        public async Task CreateFridgeCommandHandler_Success()
        {
            //Arange
            var handler = new CreateFridgeCommandHandler(_db, mapper);
            var fridgeName = "UnitTest1";
            var ownerName = "UnitOwner";
            var fridgeModelId = Guid.Parse("2767F531-6EAB-492B-99FA-839B826552E9");
            //Act
            var FridgeForCreateDto = new Domain.DTOs.FridgeForCreateDto
            {
                Name = fridgeName,
                OwnerName = ownerName,
                FridgeModelId = fridgeModelId
            };
            var fridgeId = await handler.Handle(
                new CreateFridgeCommand(FridgeForCreateDto), CancellationToken.None);
            //Assert
            Assert.NotNull(
                await _db.Fridges.SingleOrDefaultAsync(_fridge =>
                _fridge.Id == fridgeId && _fridge.Name == fridgeName &&
                _fridge.OwnerName == ownerName && _fridge.FridgeModelId == fridgeModelId));
        }
        [Fact]
        public async Task DeleteFridge_ExistingGuid_RemovesOneItem()
        {
            //Arrange
            var existingGuid = Guid.Parse("7870E84D-0F97-4196-BED7-19BD8FF40A63");
            var countBeforeDelete = await _db.Fridges.CountAsync();
            var handler = new DeleteFridgeCommandHandler(_db);

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
            await _validateFridgeExistsAtrribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var result = await handler.Handle(
                new DeleteFridgeCommand(
                    _controller.HttpContext.Items["Fridge"] as Fridge), CancellationToken.None);
            //Assert
            Assert.Equal(countBeforeDelete-1, _db.Fridges.Count());
        }
        [Fact]
        public async Task UpdateFridge_ValidObject_Success()
        {
            //Arrange
            var existingFridgeGuid = Guid.Parse("7870E84D-0F97-4196-BED7-19BD8FF40A63");
            var existingOtherFridgeModelGuid = Guid.Parse("B0463F44-AF0C-434F-9667-C3BF6C9F8A93");
            var fridgeDto = new FridgeForManipulateDto()
            {
                FridgeModelId = existingOtherFridgeModelGuid,
                Name = "Electrolux Dima Updated",
                OwnerName = "Dima Updated"
            };
            var countBeforeDelete = await _db.Fridges.CountAsync();
            var handler = new UpdateFridgeCommandHandler(_db);

            var actionExecutingContext = new ActionExecutingContext(
                _actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"id", existingFridgeGuid },
                    {"fridgeDto", fridgeDto},
                },
                _controller
            );
            //Act
            await _validateFridgeExistsAtrribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            await _validateFridgeModelForManipulateFridgeAttribute.OnActionExecutionAsync(actionExecutingContext,
    _actionExecutionDelegate.Object);
            var existingInDatabaseFridge = _controller.HttpContext.Items["Fridge"] as Fridge;
            var query = new UpdateFridgeCommand()
            {
                FridgeDto = fridgeDto,
                FridgeToChange = existingInDatabaseFridge
            };
            await handler.Handle(query, CancellationToken.None);
            //Assert
            Assert.NotNull(
                           await _db.Fridges.SingleOrDefaultAsync(_fridge =>
                           _fridge.Id == existingFridgeGuid && _fridge.Name == fridgeDto.Name &&
                           _fridge.OwnerName == fridgeDto.OwnerName && _fridge.FridgeModelId == fridgeDto.FridgeModelId));
        }        
    }
}
