using Dapper;
using System.Data;
using GolfMaxWebApi.DataAccess;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;

namespace GolfMaxWebApi.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly GolfMaxDataAccessor _dataAccessor;

    public UserRepository(GolfMaxDataAccessor dataAccessor)
    {
        _dataAccessor = dataAccessor ?? throw new ArgumentNullException(nameof(dataAccessor));
    }

    public async Task<IEnumerable<User>> FindAllAsync()
    {
        using var connection = _dataAccessor.CreateConnection();
        var users = await connection.QueryAsync<User>("GetAllUsers",
            commandType: CommandType.StoredProcedure);

        return users;
    }

    public async Task<User?> FindByUserIdAsync(int id)
    {
        using var connection = _dataAccessor.CreateConnection();
        var user = await connection.QuerySingleOrDefaultAsync<User>("GetUserById", new { id },
            commandType: CommandType.StoredProcedure);

        return user;
    }

    public async Task<User?> FindByUsernameAsync(string username)
    {
        using var connection = _dataAccessor.CreateConnection();
        var user = await connection.QuerySingleOrDefaultAsync<User>("GetUserByUsername", new { username },
            commandType: CommandType.StoredProcedure);

        return user;
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        using var connection = _dataAccessor.CreateConnection();
        var user = await connection.QuerySingleOrDefaultAsync<User>("GetUserByEmail", new { email },
            commandType: CommandType.StoredProcedure);

        return user;
    }

    public async Task<User> SaveAsync(User user)
    {
        using var connection = _dataAccessor.CreateConnection();
        var id = await connection.QuerySingleAsync<int>("InsertNewUser", new { user },
            commandType: CommandType.StoredProcedure);

        return new User
        {
            Id = id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Password = user.Password,
            Email = user.Email
        };
    }

    public async Task UpdateAsync(User user, int id)
    {
        using var connection = _dataAccessor.CreateConnection();
        await connection.ExecuteAsync("UpdateUser", new { user, id }, 
                commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteByIdAsync(int id)
    {
        using var connection = _dataAccessor.CreateConnection();
        await connection.ExecuteAsync("DeleteUser", new { id }, commandType: CommandType.StoredProcedure);
    }

    public async Task<User?> FindExistingUserAsync(User user)
    {
        using var connection = _dataAccessor.CreateConnection();
        var storedUser = await connection.QuerySingleOrDefaultAsync<User>("FindUser", new { user },
            commandType: CommandType.StoredProcedure);

        return storedUser;
    }
}