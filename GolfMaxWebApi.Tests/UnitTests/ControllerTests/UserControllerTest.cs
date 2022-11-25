using Xunit;
using Moq;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Services.Interfaces;
using GolfMaxWebApi.Controllers;
using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Mappers.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace GolfMaxWebApi.Tests.UnitTests.ControllerTests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetAllUsers_ShouldReturn_200Ok()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Kenny",
                    LastName = "McCormick",
                    Username = "kmc",
                    Password = "password",
                    Email = "kenny@email.com"
                },
                new User
                {
                    Id = 1,
                    FirstName = "Stan",
                    LastName = "Marsh",
                    Username = "sm",
                    Password = "password",
                    Email = "stan@email.com"
                },
                new User
                {
                    Id = 1,
                    FirstName = "Eric",
                    LastName = "Cartman",
                    Username = "ec",
                    Password = "password",
                    Email = "ec@email.com"
                }
            };

            var mockUserService = new Mock<IUserService>();
            var mockUserMapper = new Mock<IUserMapper>();
            var mockLogger = new Mock<ILogger<UserController>>();

            mockUserService.Setup(service => service.GetAll()).ReturnsAsync(users);

            var sut = new UserController(
                mockUserService.Object,
                mockUserMapper.Object,
                mockLogger.Object
            );

            var result = await sut.GetAllUsers();
            var expected = Assert.IsType<ActionResult<IEnumerable<UserDto>>>(result);

            Assert.IsType<OkObjectResult>(expected.Result);
        }

        [Fact]
        public async Task GetAllUsers_ShouldReturn_204NoContent()
        {
            var mockUserService = new Mock<IUserService>();
            var mockUserMapper = new Mock<IUserMapper>();
            var mockLogger = new Mock<ILogger<UserController>>();

            mockUserService.Setup(service => service.GetAll()).ReturnsAsync(value: null);

            var sut = new UserController(
                mockUserService.Object,
                mockUserMapper.Object,
                mockLogger.Object
            );

            var result = await sut.GetAllUsers();
            var expected = Assert.IsType<ActionResult<IEnumerable<UserDto>>>(result);

            Assert.IsType<NoContentResult>(expected.Result);
        }

        [Fact]
        public async Task GetUserById_ShouldReturn_200OkIfUserIsFound()
        {
            var user = new User
            {
                FirstName = "Eric",
                LastName = "Cartman",
                Username = "ec",
                Password = "password",
                Email = "ec@email.com"
            };

            var mockUserService = new Mock<IUserService>();
            var mockUserMapper = new Mock<IUserMapper>();
            var mockLogger = new Mock<ILogger<UserController>>();

            mockUserService.Setup(service => service.GetById(1)).ReturnsAsync(user);

            var sut = new UserController(
                mockUserService.Object,
                mockUserMapper.Object,
                mockLogger.Object
            );

            var result = await sut.GetUserById(1);
            var expected = Assert.IsType<OkObjectResult>(result);

            Assert.IsType<OkObjectResult>(expected);
        }

        [Fact]
        public async Task GetUserById_ShouldReturn_404NotFoundIfUserIsNotFound()
        {
            var user = new User
            {
                FirstName = "Eric",
                LastName = "Cartman",
                Username = "ec",
                Password = "password",
                Email = "ec@email.com"
            };

            var mockUserService = new Mock<IUserService>();
            var mockUserMapper = new Mock<IUserMapper>();
            var mockLogger = new Mock<ILogger<UserController>>();

            mockUserService.Setup(service => service.GetById(1)).ReturnsAsync(value: null);

            var sut = new UserController(
                mockUserService.Object,
                mockUserMapper.Object,
                mockLogger.Object
            );

            var result = await sut.GetUserById(1);
            var expected = Assert.IsType<ObjectResult>(result);

            Assert.IsType<ObjectResult>(expected);
        }

        [Fact]
        public async Task CreateUser_ShouldReturn_CreatedAtRoute()
        {
            var userDto = new UserDto
            {
                FirstName = "Randy",
                LastName = "Marsh",
                Username = "TegridyFarms",
                Email = "tegridy@gmail.com",
                Password = "Xmas-Special"
            };
            var user = new User
            {
                FirstName = "Randy",
                LastName = "Marsh",
                Username = "TegridyFarms",
                Email = "tegridy@gmail.com",
                Password = "Xmas-Special"
            };

            var mockUserService = new Mock<IUserService>();
            var mockLogger = new Mock<ILogger<UserController>>();
            var mockUserMapper = new Mock<IUserMapper>();

            mockUserService.Setup(service => service.Create(user));
            mockUserService
                .Setup(service => service.IsValidRegistrationRequest(user))
                .ReturnsAsync(true);
            mockUserMapper.Setup(mapper => mapper.ConvertToEntity(userDto)).Returns(user);

            var sut = new UserController(
                mockUserService.Object,
                mockUserMapper.Object,
                mockLogger.Object
            );

            var result = await sut.Register(userDto);
            var expected = Assert.IsType<ActionResult<UserDto>>(result);

            Assert.IsType<ObjectResult>(expected.Result);
        }
    }
}