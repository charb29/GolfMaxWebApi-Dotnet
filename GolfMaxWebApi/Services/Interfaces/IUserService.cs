using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Update(User user, int id);
        Task<User?> GetById(int id);
        Task<User> Create(User user);
        Task DeleteById(int id);
        Task<bool> IsValidRegistrationRequest(User user);
        Task<bool> IsValidLoginRequest(User user);
    }
}
