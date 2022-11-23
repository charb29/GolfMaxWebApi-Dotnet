using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> FindAll();
        Task<User?> FindByUserId(int id);
        Task<User?> FindByUsername(string username);
        Task<User?> FindByEmail(string email);
        Task<User> Save(User user);
        Task Update(User user, int id);
        Task DeleteById(int id);
        Task<User?> FindExistingUser(User user);
        Task<string?> GetPasswordUsingUsername(string username);
    }
}
