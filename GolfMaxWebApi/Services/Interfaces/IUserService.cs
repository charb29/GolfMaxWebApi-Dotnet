using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> UpdateAsync(User user, int id);
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task DeleteByIdAsync(int id);
    Task<bool> IsValidRegistrationRequestAsync(User user);
    Task<bool> IsValidLoginRequestAsync(User user);
}