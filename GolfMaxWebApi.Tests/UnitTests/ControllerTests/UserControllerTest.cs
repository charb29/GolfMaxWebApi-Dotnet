using GolfMaxWebApi.Controllers;
using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Mappers.Interfaces;
using GolfMaxWebApi.Services.Interfaces;
using GolfMaxWebApi.Tests.MockObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace GolfMaxWebApi.Tests.UnitTests.ControllerTests;

public class UserControllerTests
{
    [Fact]
    public async Task GetAllUsers_ShouldReturn_200Ok_IfUsersArePresent()
    {
        var mockUserService = new Mock<IUserService>();
        var mockUserMapper = new Mock<IUserMapper>();
        var mockLogger = new Mock<ILogger<UserController>>();

        mockUserService.Setup(service => service.GetAllAsync()).ReturnsAsync(MockUser.Users());

        var sut = new UserController(mockUserService.Object, mockUserMapper.Object, mockLogger.Object);
        var result = await sut.GetAllUsers();
        var expected = Assert.IsType<ActionResult<IEnumerable<UserDto>>>(result);

        Assert.IsType<OkObjectResult>(expected.Result);
    }

    [Fact]
    public async Task GetAllUsers_ShouldReturn_204NoContent_IfListIsNull()
    {
        var mockUserService = new Mock<IUserService>();
        var mockUserMapper = new Mock<IUserMapper>();
        var mockLogger = new Mock<ILogger<UserController>>();

        mockUserService.Setup(service => service.GetAllAsync())!.ReturnsAsync(value: null);

        var sut = new UserController(mockUserService.Object, mockUserMapper.Object, mockLogger.Object);
        var result = await sut.GetAllUsers();
        var expected = Assert.IsType<ActionResult<IEnumerable<UserDto>>>(result);

        Assert.IsType<NoContentResult>(expected.Result);
    }

    [Fact]
    public async Task GetUserById_ShouldReturn_200Ok_IfUserIsFound()
    {
        var mockUserService = new Mock<IUserService>();
        var mockUserMapper = new Mock<IUserMapper>();
        var mockLogger = new Mock<ILogger<UserController>>();

        mockUserService.Setup(service => service.GetByIdAsync(MockUser.User().Id))
            .ReturnsAsync(MockUser.User());

        var sut = new UserController(mockUserService.Object, mockUserMapper.Object, mockLogger.Object);
        var result = await sut.GetUserById(MockUser.User().Id);
        var expected = Assert.IsType<OkObjectResult>(result);

        Assert.IsType<OkObjectResult>(expected);
    }

    [Fact]
    public async Task GetUserById_ShouldReturn_404NotFound_IfNoUserFound()
    {
        var mockUserService = new Mock<IUserService>();
        var mockUserMapper = new Mock<IUserMapper>();
        var mockLogger = new Mock<ILogger<UserController>>();

        mockUserService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(value: null);

        var sut = new UserController(mockUserService.Object, mockUserMapper.Object, mockLogger.Object);
        var result = await sut.GetUserById(1);
        var expected = Assert.IsType<ObjectResult>(result);

        Assert.IsType<ObjectResult>(expected);
    }

    [Fact]
    public async Task CreateUser_ShouldReturn_CreatedAtRoute()
    {
        var mockUserService = new Mock<IUserService>();
        var mockLogger = new Mock<ILogger<UserController>>();
        var mockUserMapper = new Mock<IUserMapper>();

        mockUserService.Setup(service => service.CreateAsync(MockUser.User()));
        mockUserService.Setup(service => service.IsValidRegistrationRequestAsync(MockUser.User()))
            .ReturnsAsync(true);
        mockUserMapper.Setup(mapper => mapper.ConvertToEntity(MockUser.UserDto())).Returns(MockUser.User());

        var sut = new UserController(mockUserService.Object, mockUserMapper.Object, mockLogger.Object);
        var result = await sut.Register(MockUser.UserDto());
        var expected = Assert.IsType<ActionResult<UserDto>>(result);

        Assert.IsType<ObjectResult>(expected.Result);
    }
}