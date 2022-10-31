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
using System.Threading;
using System.Threading.Tasks;
using UnitTests.MoqObjects;
using Xunit;
using Filters.ActionFilters.FridgeModelFilters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Application.Services.Interfaces;
using Application.QueryHandlers.FridgeModels;
using Application.Queries.FridgeModels;
using Application.Contracts.FridgeModels;
using Application.CommandHandlers.FridgeModels;
using Application.Contracts.Fridges;
using Application.Commands.FridgeModels;
using Domain.Entities;

namespace UnitTests.Tests
{
    public class FridgeModelControllerTests : IDisposable
    {
        private readonly ValidateFridgeModelExistsAttribute _validateFridgeModelExistsAttribute;
        private readonly Mock<ActionExecutionDelegate> _actionExecutionDelegate;
        private readonly ActionContext _actionContext;
        private readonly IMapper mapper;
        private readonly FridgeModelController _controller;
        private readonly Mock<IMediator> Mediatr;
        private readonly FridgeDbContext _db;
        public FridgeModelControllerTests()
        {
            var loggerManagerMock = new Mock<ILoggerManager>();
            Mediatr = new Mock<IMediator>();

            _db = FridgeDbContextFactory.Create();

            var httpContext = new DefaultHttpContext();
            _controller = new FridgeModelController(Mediatr.Object)
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

            _validateFridgeModelExistsAttribute = new ValidateFridgeModelExistsAttribute(
                _db, loggerManagerMock.Object);
        }
        public void Dispose()
        {
            FridgeDbContextFactory.Destroy(_db);
        }

        [Fact]
        public async Task GetAllFridgeModelsCommandHandler_Success()
        {
            //Arrange
            var handler = new GetAllFridgeModelsQueryHandler(_db, mapper);

            //Act
            var models = await handler.Handle(
                new GetAllFridgeModelsQuery(), CancellationToken.None);

            //Assert
            Assert.IsType<List<FridgeModelDto>>(models);
            Assert.Equal(_db.FridgeModels.Count(), models.Count());
        }
        [Fact]
        public async Task ValidateFridgeModelExistsAtrribute_WithUnknownGuid_ReturnNotFoundObjectResult()
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
            await _validateFridgeModelExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var notFoundResult = actionExecutingContext.Result;

            //Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public async Task ValidateFridgeModelExistsAtrribute_WithExistingGuid_ReturnRightItem()
        {
            //Arrange
            var testGuid = Guid.Parse("D957B9BE-B351-4629-A332-4841851AA395");

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
            await _validateFridgeModelExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var model = _controller.HttpContext.Items["FridgeModel"] as FridgeModel;

            //Assert
            Assert.IsType<FridgeModel>(model);
            Assert.Equal(testGuid, model.Id);
        }
        [Fact]
        public async Task CreateFridgeModelCommandHandler_Success()
        {
            //Arange
            var handler = new CreateFridgeModelCommandHandler(_db, mapper);
            var ModelName = "Bosch Serie 8 VitaFresh Plus KGN39LB32R";
            var Year = 2020;
            //Act
            var fridgeModelDto = new FridgeModelForManipulateDto
            {
                Name = ModelName,
                Year = Year
            };
            var modelId = await handler.Handle(
                new CreateFridgeModelCommand(fridgeModelDto), CancellationToken.None);
            //Assert
            Assert.NotNull(
                await _db.FridgeModels.SingleOrDefaultAsync(_model =>
                _model.Id == modelId && _model.Name == ModelName &&
                _model.Year == Year));
        }
        [Fact]
        public async Task DeleteFridgeModel_ExistingGuid_RemovesOneItem()
        {
            //Arrange
            var existingGuid = Guid.Parse("D957B9BE-B351-4629-A332-4841851AA395");
            var countBeforeDelete = await _db.FridgeModels.CountAsync();
            var handler = new DeleteFridgeModelCommandHandler(_db);

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
            await _validateFridgeModelExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var result = await handler.Handle(
                new DeleteFridgeModelCommand(
                    _controller.HttpContext.Items["FridgeModel"] as FridgeModel), CancellationToken.None);
            //Assert
            Assert.Equal(countBeforeDelete - 1, _db.FridgeModels.Count());
        }
        [Fact]
        public async Task UpdateFridgeModel_ValidObject_Success()
        {
            //Arrange
            var existingGuid = Guid.Parse("B0463F44-AF0C-434F-9667-C3BF6C9F8A93");
            var modelDto = new FridgeModelForManipulateDto()
            {
                Name = "ATLANT ХМ 4307",
                Year = 2020
            };
            var countBeforeDelete = await _db.FridgeModels.CountAsync();
            var handler = new UpdateFridgeModelCommandHandler(_db, mapper);

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
            await _validateFridgeModelExistsAttribute.OnActionExecutionAsync(actionExecutingContext,
                _actionExecutionDelegate.Object);
            var existingInDatabaseModel = _controller.HttpContext.Items["FridgeModel"] as FridgeModel;
            var query = new UpdateFridgeModelCommand()
            {
                FridgeModelDto = modelDto,
                FridgeModelToChange = existingInDatabaseModel
            };
            await handler.Handle(query, CancellationToken.None);
            //Assert
            Assert.NotNull(
                           await _db.FridgeModels.SingleOrDefaultAsync(_model =>
                           _model.Id == existingGuid && _model.Name == modelDto.Name &&
                           _model.Year == modelDto.Year));
        }
    }
}
