using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Models.Mappers.Interfaces;

namespace GolfMaxWebApi.Models.Mappers.Implementations
{
    public class UserMapper : IUserMapper
    {
        public UserDto ConvertToUserDto(User user)
        {
            return new UserDto
            {
                Username = user.Username,
                Email = user.Email
            };
        }

        public IEnumerable<UserDto> ConvertToUserDtoList(IEnumerable<User> users)
        {
            var userDtos = new List<UserDto>();
            foreach (User user in users)
            {
                userDtos.Add(ConvertToUserDto(user));
            }
            return userDtos;
        }

        public User ConvertToEntity(UserDto userDto)
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Email = userDto.Email,

            };
        }
    }
}
