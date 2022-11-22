using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> FindAll();
        Task<User> FindByUserId(int id);
        Task<User> FindByUsername(string username);
        Task<User> Save(User user);
        Task<User> Update(User user);
        Task DeleteById(int id);
        Task<bool> ExistsByUsername(string username);
        Task<bool> ExistsByEmail(string email);
        Task<string> GetPasswordUsingUsername(string username);
    }
}
