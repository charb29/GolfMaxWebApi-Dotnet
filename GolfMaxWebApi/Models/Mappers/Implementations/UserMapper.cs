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
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email
            };
        }

        public List<UserDto> ConvertToUserDtoList(List<User> users)
        {
            var userDtoList = new List<UserDto>();
            foreach (User user in users)
            {
                userDtoList.Add(ConvertToUserDto(user));
            }
            return userDtoList;
        }

        public User ConvertToEntity(UserDto userDto)
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }
    }
}
