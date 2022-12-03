using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Models.Mappers.Interfaces;

namespace GolfMaxWebApi.Models.Mappers.Implementations;

public class UserMapper : IUserMapper
{
    public UserDto ConvertToUserDto(User user)
    {
        return new UserDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Email = user.Email,
            Password = user.Password
        };
    }

    public IEnumerable<UserDto> ConvertToUserDtoList(IEnumerable<User> users)
    {
        var userDtos = users.Select(ConvertToUserDto).ToList();
        return userDtos;
    }

    public User ConvertToEntity(UserDto userDto)
    {
        return new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Username = userDto.Username ?? throw new ArgumentNullException(nameof(userDto.Username)),
            Email = userDto.Email ?? throw new ArgumentNullException(nameof(userDto.Email)),
            Password = userDto.Password ?? throw new ArgumentNullException(nameof(userDto.Password))
        };
    }
}