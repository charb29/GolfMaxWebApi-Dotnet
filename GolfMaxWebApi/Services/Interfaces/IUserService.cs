using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> Update(User userRequest, int id);
        Task<User> GetById(int id);
        Task<User> Create(User user);
        Task DeleteById(int id);
        Task<bool> IsValidRegistrationRequest(User user);
        Task<bool> IsValidUsername(string username);
        Task<bool> IsValidEmail(string email);
        Task<bool> IsValidLoginRequest(User user);
    }
}
