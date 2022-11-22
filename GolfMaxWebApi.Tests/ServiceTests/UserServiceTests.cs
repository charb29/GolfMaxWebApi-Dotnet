using GolfMaxWebApi.Models.Entities;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Repositories.Implementations;
using GolfMaxWebApi.Services.Interfaces;
using GolfMaxWebApi.Services.Implementations;

namespace GolfMaxWebApi.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task IfUsersAreInDatabase_ReturnListOfUsers()
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

            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.FindAll()).ReturnsAsync(users);

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var actual = await sut.GetAll();
            var expected = users;

            Assert.Equal(expected, actual);
            mockRepo.Verify(repo => repo.FindAll(), Times.Once());
        }

        [Fact]
        public async Task IfDatabaseHasNoUsers_ReturnEmptyList()
        {
            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.FindAll()).ReturnsAsync(new List<User>());

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var result = await sut.GetAll();

            Assert.Empty(result);
            mockRepo.Verify(repo => repo.FindAll(), Times.Once());
        }

        [Fact]
        public async Task GetById_ShouldReturn_UserWithAssociatedID()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "Ike",
                LastName = "Broflovski",
                Username = "Ike",
                Password = "password",
                Email = "ike@southpark.com"
            };

            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.FindByUserId(1)).ReturnsAsync(user);

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var actual = await sut.GetById(1);
            var expected = user;

            Assert.Equal(expected, actual);
            mockRepo.Verify(repo => repo.FindByUserId(1), Times.Once());
        }

        [Fact]
        public async Task Create_ShouldReturn_CreatedUser()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "Ike",
                LastName = "Broflovski",
                Username = "Ike",
                Password = "password",
                Email = "ike@southpark.com"
            };

            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.Save(It.IsAny<User>())).ReturnsAsync(user);

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var actual = await sut.Create(user);
            var expected = user;

            Assert.Equal(expected, actual);
            mockRepo.Verify(repo => repo.Save(It.IsAny<User>()), Times.Once());
        }

        [Fact]
        public void DeleteById_ShouldThrowException_IfUserDoesNotExist()
        {
            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo
                .Setup(repo => repo.DeleteById(It.IsAny<int>()))
                .Throws(new ArgumentNullException("id"));

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var result = sut.DeleteById(It.IsAny<int>());

            Assert.ThrowsAsync<System.ArgumentNullException>(() => result);
            mockRepo.Verify(repo => repo.DeleteById(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public async Task IsValidUsername_ShouldReturnTrue_IfUsernameIsAvailable()
        {
            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.ExistsByUsername(It.IsAny<string>())).ReturnsAsync(true);

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var result = await sut.IsValidUsername(It.IsAny<string>());

            Assert.True(result);
            mockRepo.Verify(repo => repo.ExistsByUsername(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task IsValidUsername_ShouldReturnFalse_IfUsernameTaken()
        {
            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.ExistsByUsername(It.IsAny<string>())).ReturnsAsync(false);

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var result = await sut.IsValidUsername(It.IsAny<string>());

            Assert.False(result);
            mockRepo.Verify(repo => repo.ExistsByUsername(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task IsValidEmail_ShouldReturnTrue_IfEmailIsAvailable()
        {
            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.ExistsByEmail(It.IsAny<string>())).ReturnsAsync(true);

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var result = await sut.IsValidEmail(It.IsAny<string>());

            Assert.True(result);
            mockRepo.Verify(repo => repo.ExistsByEmail(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task IsValidEmail_ShouldReturnFalse_IfEmailTaken()
        {
            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.ExistsByEmail(It.IsAny<string>())).ReturnsAsync(false);

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var result = await sut.IsValidEmail(It.IsAny<string>());

            Assert.False(result);
            mockRepo.Verify(repo => repo.ExistsByEmail(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task IsValidLoginRequest_ShouldReturn_True()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "Ike",
                LastName = "Broflovski",
                Username = "Ike",
                Password = "password",
                Email = "ike@southpark.com"
            };

            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.ExistsByUsername(user.Username)).ReturnsAsync(true);
            mockRepo
                .Setup(repo => repo.GetPasswordUsingUsername(user.Username))
                .ReturnsAsync(user.Password);

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var result = await sut.IsValidLoginRequest(user);

            Assert.True(result);

            mockRepo.Verify(repo => repo.ExistsByUsername(It.IsAny<string>()), Times.Once());
            mockRepo.Verify(repo => repo.GetPasswordUsingUsername(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task IsValidLoginRequest_ShouldReturn_FalseIfUserDoesNotExist()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "Ike",
                LastName = "Broflovski",
                Username = "Ike",
                Password = "password",
                Email = "ike@southpark.com"
            };

            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.ExistsByUsername(It.IsAny<string>())).ReturnsAsync(false);
            mockRepo
                .Setup(repo => repo.GetPasswordUsingUsername(user.Username))
                .ReturnsAsync(user.Password);

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var result = await sut.IsValidLoginRequest(user);

            Assert.False(result);
            mockRepo.Verify(repo => repo.ExistsByUsername(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task IsValidRegistrationRequest_ShouldReturn_True()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "Kenny",
                LastName = "McCormick",
                Username = "kmc",
                Password = "password",
                Email = "kenny@email.com"
            };

            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.ExistsByUsername(It.IsAny<string>())).ReturnsAsync(false);
            mockRepo.Setup(repo => repo.ExistsByEmail(It.IsAny<string>())).ReturnsAsync(false);

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var result = await sut.IsValidRegistrationRequest(user);

            Assert.True(result);
        }

        [Fact]
        public async Task IsValidRegistrationRequest_ShouldReturn_FalseIfUsernameAndEmailAreAlreadyTaken()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "Kenny",
                LastName = "McCormick",
                Username = "kmc",
                Password = "password",
                Email = "kenny@email.com"
            };

            var mockRepo = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            mockRepo.Setup(repo => repo.ExistsByUsername(It.IsAny<string>())).ReturnsAsync(true);
            mockRepo.Setup(repo => repo.ExistsByEmail(It.IsAny<string>())).ReturnsAsync(true);

            var sut = new UserService(mockRepo.Object, mockLogger.Object);
            var result = await sut.IsValidRegistrationRequest(user);

            Assert.False(result);
        }
    }
}