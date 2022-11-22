using Xunit;
using GolfMaxWebApi.Models.Mappers.Implementations;
using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Entities;
using System.Collections.Generic;

namespace GolfMaxWebApi.Tests
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

            var sut = new UserMapper();

            var actualResult = sut.ConvertToUserDto(user);
            var expectedResult = new UserDto
            {
                FirstName = "Kenny",
                LastName = "McCormick",
                Username = "opc_29",
                Email = "olivier@gmail.com"
            };

            Assert.Equal(expectedResult.FirstName, actualResult.FirstName);
            Assert.Equal(expectedResult.LastName, actualResult.LastName);
            Assert.Equal(expectedResult.Username, actualResult.Username);
            Assert.Equal(expectedResult.Email, actualResult.Email);
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

            var sut = new UserMapper();
            var actualResult = sut.ConvertToUserDtoList(users);
            const int expectedResult = 3;

            Assert.Equal(expectedResult, actualResult.Count);
        }
    }
}
