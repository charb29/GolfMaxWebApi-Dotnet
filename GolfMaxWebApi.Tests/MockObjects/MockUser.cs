using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Tests.MockObjects;

public static class MockUser
{
    public static List<User> Users()
    {
        return new List<User>
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
    }

    public static User User()
    {
        return new User
        {
            Id = 1,
            FirstName = "Ike",
            LastName = "Broflovski",
            Username = "Ike",
            Password = "password",
            Email = "ike@southpark.com"
        };
    }

    public static UserDto UserDto()
    {
        return new UserDto
        {
            FirstName = "Ike",
            LastName = "Broflovski",
            Username = "Ike",
            Password = "password",
            Email = "ike@southpark.com"
        };
    }
}