using GolfMaxWebApi.Models.Entities;
using Xunit;
using Moq;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Implementations;

namespace GolfMaxWebApi.Tests.UnitTests.ServiceTests
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
            var expected = users;

            mockRepo.Setup(repo => repo.FindAll())
                .ReturnsAsync(users);

            var sut = new UserService(mockRepo.Object);
            var actual = await sut.GetAll();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task IfDatabaseHasNoUsers_ReturnEmptyList()
        {
            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(repo => repo.FindAll())
                .ReturnsAsync(new List<User>());

            var sut = new UserService(mockRepo.Object);
            var result = await sut.GetAll();

            Assert.Empty(result);
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
            var expected = user;

            mockRepo.Setup(repo => repo.FindByUserId(1))
                .ReturnsAsync(user);

            var sut = new UserService(mockRepo.Object);
            var actual = await sut.GetById(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Create_ShouldReturn_CreatedUser()
        {
            var user = new User
            {
                FirstName = "Ike",
                LastName = "Broflovski",
                Username = "Ike",
                Password = "password",
                Email = "ike@southpark.com"
            };

            var mockRepo = new Mock<IUserRepository>();
            var expected = user;

            mockRepo.Setup(repo => repo.Save(user))
                .ReturnsAsync(user);

            var sut = new UserService(mockRepo.Object);
            var actual = await sut.Create(user);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DeleteById_ShouldThrowException_IfUserDoesNotExist()
        {
            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(repo => repo.DeleteById(It.IsAny<int>()))
                    .Throws(new ArgumentNullException("id"));

            var sut = new UserService(mockRepo.Object);
            var result = sut.DeleteById(It.IsAny<int>());

            Assert.ThrowsAsync<ArgumentNullException>(() => result);
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

            mockRepo.Setup(repo => repo.FindByUsername(user.Username))
                .ReturnsAsync(user);

            var sut = new UserService(mockRepo.Object);
            var result = await sut.IsValidLoginRequest(user);

            Assert.True(result);
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

            mockRepo.Setup(repo => repo.FindByUsername(user.Username))
                    .ReturnsAsync(value: null);

            var sut = new UserService(mockRepo.Object);
            var result = await sut.IsValidLoginRequest(user);

            Assert.False(result);
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

            mockRepo.Setup(repo => repo.FindExistingUser(user))
                .ReturnsAsync(value: null);

            var sut = new UserService(mockRepo.Object);
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

            mockRepo.Setup(repo => repo.FindExistingUser(user))
                .ReturnsAsync(user);

            var sut = new UserService(mockRepo.Object);
            var result = await sut.IsValidRegistrationRequest(user);

            Assert.False(result);
        }
    }
}