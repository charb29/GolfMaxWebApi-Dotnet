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

        var user = await connection.QuerySingleOrDefaultAsync<User>("GetUserById", 
            new { Id = id }, 
            commandType: CommandType.StoredProcedure);
        
        return user;
    }

    public async Task<User?> FindByUsernameAsync(string username)
    {
        using var connection = _dataAccessor.CreateConnection();
        
        var user = await connection.QuerySingleOrDefaultAsync<User>("GetUserByUsername", 
            new { Username = username },
            commandType: CommandType.StoredProcedure);

        return user;
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        using var connection = _dataAccessor.CreateConnection();

        var user = await connection.QuerySingleOrDefaultAsync<User>("GetUserByEmail", 
            new { Email = email },
            commandType: CommandType.StoredProcedure);

        return user;
    }

    public async Task<User> SaveAsync(User user)
    {
        using var connection = _dataAccessor.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("FirstName", user.FirstName);
        parameters.Add("LastName", user.LastName);
        parameters.Add("Username", user.Username);
        parameters.Add("Password", user.Password);
        parameters.Add("Email", user.Email);
        
        var insertedId = await connection.QuerySingleAsync<int>("InsertUser", parameters,
            commandType: CommandType.StoredProcedure);

        return new User
        {
            Id = insertedId,
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
        
        var parameters = new DynamicParameters();
        parameters.Add("Username", user.Username);
        parameters.Add("Password", user.Password);
        parameters.Add("Email", user.Email);
        parameters.Add("Id", id);
        
        await connection.ExecuteAsync("UpdateUser", 
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteByIdAsync(int id)
    {
        using var connection = _dataAccessor.CreateConnection();
        
        await connection.ExecuteAsync("DeleteUser", 
            new { Id = id }, 
            commandType: CommandType.StoredProcedure);
    }

    public async Task<User?> FindExistingUserAsync(User user)
    {
        using var connection = _dataAccessor.CreateConnection();
        
        var parameters = new DynamicParameters();
        parameters.Add("Username", user.Username);
        parameters.Add("Email", user.Email);
        parameters.Add("Id", user.Id);
        
        var storedUser = await connection.QuerySingleOrDefaultAsync<User>("FindExistingUser", 
            parameters,
            commandType: CommandType.StoredProcedure);

        return storedUser;
    }
}