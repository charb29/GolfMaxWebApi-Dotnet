using System.Diagnostics;
using GolfMaxWebApi.Models.Entities;
using Moq;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Implementations;
using GolfMaxWebApi.Tests.MockObjects;

namespace GolfMaxWebApi.Tests.UnitTests.ServiceTests;

public class UserServiceTests
{
    [Fact]
    public async Task IfUsersAreInDatabase_ReturnListOfUsers()
    {
        var mockRepo = new Mock<IUserRepository>();
        var expected = MockUser.Users();

        mockRepo.Setup(repo => repo.FindAllAsync()).ReturnsAsync(MockUser.Users);

        var sut = new UserService(mockRepo.Object);
        var actual = await sut.GetAllAsync();

        Assert.Equal(expected.Select(user => user.Username), actual.Select(user => user.Username));
        Assert.Equal(expected.Select(user => user.Password), actual.Select(user => user.Password));
        Assert.Equal(expected.Select(user => user.Email), actual.Select(user => user.Email));
    }

    [Fact]
    public async Task IfDatabaseHasNoUsers_ReturnEmptyList()
    {
        var mockRepo = new Mock<IUserRepository>();

        mockRepo.Setup(repo => repo.FindAllAsync()).ReturnsAsync(new List<User>());

        var sut = new UserService(mockRepo.Object);
        var result = await sut.GetAllAsync();

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

        mockRepo.Setup(repo => repo.FindByUserIdAsync(user.Id))
            .ReturnsAsync(user);

        var sut = new UserService(mockRepo.Object);
        var actual = await sut.GetByIdAsync(user.Id);

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

        mockRepo.Setup(repo => repo.SaveAsync(user)).ReturnsAsync(user);

        var sut = new UserService(mockRepo.Object);
        var actual = await sut.CreateAsync(user);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DeleteById_ShouldThrowException_IfUserDoesNotExist()
    {
        var mockRepo = new Mock<IUserRepository>();

        mockRepo.Setup(repo => repo.DeleteByIdAsync(It.IsAny<int>()))
            .Throws(new ArgumentNullException($"id"));

        var sut = new UserService(mockRepo.Object);
        var result = sut.DeleteByIdAsync(It.IsAny<int>());

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

        mockRepo.Setup(repo => repo.FindByUsernameAsync(user.Username))
            .ReturnsAsync(user);

        var sut = new UserService(mockRepo.Object);
        var result = await sut.IsValidLoginRequestAsync(user);

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

        mockRepo.Setup(repo => repo.FindByUsernameAsync(user.Username))
            .ReturnsAsync(value: null);

        var sut = new UserService(mockRepo.Object);
        var result = await sut.IsValidLoginRequestAsync(user);

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

        mockRepo.Setup(repo => repo.FindExistingUserAsync(user))
            .ReturnsAsync(value: null);

        var sut = new UserService(mockRepo.Object);
        var result = await sut.IsValidRegistrationRequestAsync(user);

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

        mockRepo.Setup(repo => repo.FindExistingUserAsync(user))
            .ReturnsAsync(user);

        var sut = new UserService(mockRepo.Object);
        var result = await sut.IsValidRegistrationRequestAsync(user);

        Assert.False(result);
    }
}