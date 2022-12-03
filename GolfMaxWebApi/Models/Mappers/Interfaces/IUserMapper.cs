using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Models.Mappers.Interfaces;

public interface IUserMapper
{
    UserDto ConvertToUserDto(User user);
    IEnumerable<UserDto> ConvertToUserDtoList(IEnumerable<User> users);
    User ConvertToEntity(UserDto userDto);
}