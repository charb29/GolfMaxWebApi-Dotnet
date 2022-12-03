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
        _dataAccessor = dataAccessor ?? 
                        throw new ArgumentNullException(nameof(dataAccessor));
    }

    public async Task<IEnumerable<User>> FindAllAsync()
    {
        const string query = "SELECT * FROM users";

        using var connection = _dataAccessor.CreateConnection();
        var users = await connection.QueryAsync<User>(query);

        return users;
    }

    public async Task<User?> FindByUserIdAsync(int id)
    {
        const string query = "SELECT * FROM users u " +
                             "WHERE id = @id";

        using var connection = _dataAccessor.CreateConnection();
        var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { id });

        return user;
    }

    public async Task<User?> FindByUsernameAsync(string username)
    {
        const string query = "SELECT * FROM users u " +
                             "WHERE u.username = @username";

        using var connection = _dataAccessor.CreateConnection();
        var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { username });

        return user;
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        const string query = "SELECT * FROM users u " +
                             "WHERE u.email = @email";

        using var connection = _dataAccessor.CreateConnection();
        var user = await connection.QuerySingleOrDefaultAsync(query, new { email });

        return user;
    }

    public async Task<User> SaveAsync(User user)
    {
        const string query = "INSERT INTO users (first_name, last_name, username, password, email) " +
                             "VALUES (@FirstName, @LastName, @Username, @Password, @Email);" +
                             "SELECT LAST_INSERT_ID();";

        using var connection = _dataAccessor.CreateConnection();
        var id = await connection.QuerySingleAsync<int>(query, user);

        return new User
        {
            Id = id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Username = user.Username,
            Password = user.Password,
        };
    }

    public async Task UpdateAsync(User user, int id)
    {
        const string query = "UPDATE users u SET " +
                             "u.first_name = @FirstName, " +
                             "u.last_name = @LastName,  " +
                             "u.username = @Username, " +
                             "u.password = @Password, " +
                             "u.email = @Email " +
                             "WHERE u.id = @id";

        var parameters = new DynamicParameters();
        parameters.Add("id", id, DbType.Int32);
        parameters.Add("FirstName", user.FirstName, DbType.String);
        parameters.Add("LastName", user.LastName, DbType.String);
        parameters.Add("Username", user.Username, DbType.String);
        parameters.Add("Password", user.Password, DbType.String);
        parameters.Add("Email", user.Email, DbType.String);

        using var connection = _dataAccessor.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task DeleteByIdAsync(int id)
    {
        const string query = "DELETE FROM users u " +
                             "WHERE u.id = @id";

        using var connection = _dataAccessor.CreateConnection();
        await connection.ExecuteAsync(query, new { id });
    }

    public async Task<User?> FindExistingUserAsync(User user)
    {
        const string query = "SELECT * FROM users u " +
                             "WHERE u.username = @username " +
                             "OR u.email = @email";

        var parameters = new DynamicParameters();
        parameters.Add("username", user.Username, DbType.String);
        parameters.Add("email", user.Email, DbType.String);

        using var connection = _dataAccessor.CreateConnection();
        var storedUser = await connection.QuerySingleOrDefaultAsync<User>(query, parameters);

        return storedUser;
    }

    public async Task<string?> GetPasswordUsingUsernameAsync(string username)
    {
        const string query = "SELECT u.password FROM users u " +
                             "WHERE u.username = @username";

        var parameters = new DynamicParameters();
        parameters.Add("username", username, DbType.String);

        using var connection = _dataAccessor.CreateConnection();
        var storedPassword = await connection.QuerySingleOrDefaultAsync<string>(query, parameters);

        return storedPassword;
    }
}