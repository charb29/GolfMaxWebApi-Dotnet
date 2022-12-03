using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Repositories.Interfaces;

public interface  IUserRepository
{
    Task<IEnumerable<User>> FindAllAsync();
    Task<User?> FindByUserIdAsync(int id);
    Task<User?> FindByUsernameAsync(string username);
    Task<User> SaveAsync(User user);
    Task UpdateAsync(User user, int id);
    Task DeleteByIdAsync(int id);
    Task<User?> FindExistingUserAsync(User user);
}