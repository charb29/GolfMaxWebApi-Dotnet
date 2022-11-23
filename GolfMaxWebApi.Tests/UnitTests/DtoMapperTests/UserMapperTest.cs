using Xunit;
using GolfMaxWebApi.Models.Mappers.Implementations;
using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Tests.UnitTests.DtoMapperTests
{
    public class UserMapperTests
    {
        [Fact]
        public void MapEntityToDto_ReturnsDto()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "Kenny",
                LastName = "McCormick",
                Username = "opc_29",
                Password = "password",
                Email = "olivier@gmail.com",
            };

            var expected = new UserDto
            {
                FirstName = "Kenny",
                LastName = "McCormick",
                Username = "opc_29",
                Email = "olivier@gmail.com"
            };

            var sut = new UserMapper();

            var actual = sut.ConvertToUserDto(user);

            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.Username, actual.Username);
            Assert.Equal(expected.Email, actual.Email);
        }

        [Fact]
        public void MapEntityListToDto_ReturnsListOfDto()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Olivier",
                    LastName = "Charbonneau",
                    Username = "opc_29",
                    Password = "password",
                    Email = "olivier@gmail.com",
                },
                new User
                {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Knezovich",
                    Username = "ak_47",
                    Password = "password",
                    Email = "ak@gmail.com",
                },
                new User
                {
                    Id = 3,
                    FirstName = "Eric",
                    LastName = "Charbonneau",
                    Username = "ec",
                    Password = "password",
                    Email = "eric@gmail.com",
                }
            };
            const int expected = 3;

            var sut = new UserMapper();
            var actual = sut.ConvertToUserDtoList(users);

            Assert.Equal(expected, actual.Count());
        }
    }
}
