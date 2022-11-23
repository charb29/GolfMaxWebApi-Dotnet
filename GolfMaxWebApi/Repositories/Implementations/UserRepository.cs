using Dapper;
using System.Data;
using GolfMaxWebApi.DataAccess;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;

namespace GolfMaxWebApi.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly GolfMaxDataAccessor _dataAccessor;

        public UserRepository(GolfMaxDataAccessor dataAccessor)
        {
            _dataAccessor = dataAccessor;
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            const string query = "SELECT * FROM users";

            using var connection = _dataAccessor.CreateConnection();
            var users = await connection.QueryAsync<User>(query);

            return users;
        }

        public async Task<User?> FindByUserId(int id)
        {
            var query = "SELECT * FROM users WHERE id = @id";

            using var connection = _dataAccessor.CreateConnection();
            var user = await connection.QueryAsync<User>(query, new { id });

            return user.SingleOrDefault();
        }

        public async Task<User?> FindByUsername(string username)
        {
            var query = "SELECT * FROM users u WHERE u.username = @username";

            using var connection = _dataAccessor.CreateConnection();
            var user = await connection.QueryAsync<User>(query, new { username });

            return user.SingleOrDefault();
        }

        public async Task<User?> FindByEmail(string email)
        {
            var query = "SELECT * FROM users u WHERE u.email = @email";

            using var connection = _dataAccessor.CreateConnection();
            var user = await connection.QueryAsync(query, new { email });

            return user.SingleOrDefault();
        }

        public async Task<User> Save(User user)
        {
            var query = "INSERT INTO users (first_name, last_name, username, password, email)"
                + " VALUES (@FirstName, @LastName, @Username, @Password, @Email)";

            var parameters = new DynamicParameters();
            parameters.Add("FirstName", user.FirstName, DbType.String);
            parameters.Add("LastName", user.LastName, DbType.String);
            parameters.Add("Username", user.Username, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            parameters.Add("Email", user.Email, DbType.String);

            using var connection = _dataAccessor.CreateConnection();
            var id = await connection.ExecuteAsync(query, parameters);

            var createdUser = new User
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
            };
            return createdUser;
        }

        public async Task Update(User user, int id)
        {
            var query = "UPDATE users u SET"
                + " u.first_name = @FirstName,"
                + " u.last_name = @LastName,"
                + " u.username = @Username,"
                + " u.password = @Password,"
                + " u.email = @Email"
                + " WHERE u.id = @id";

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

        public async Task DeleteById(int id)
        {
            var query = "DELETE FROM users u WHERE u.id = @id";

            using var connection = _dataAccessor.CreateConnection();
            await connection.ExecuteAsync(query, new { id });
        }

        public async Task<User?> FindExistingUser(User user)
        {
            var query = "SELECT * FROM users u WHERE u.username = @username OR u.email = @email";

            var parameters = new DynamicParameters();
            parameters.Add("username", user.Username, DbType.String);
            parameters.Add("email", user.Email, DbType.String);

            using var connection = _dataAccessor.CreateConnection();
            var storedUser = await connection.QueryAsync<User>(query, parameters);

            return storedUser.SingleOrDefault();
        }

        public async Task<string?> GetPasswordUsingUsername(string username)
        {
            var query = "SELECT u.password FROM users u WHERE u.username = @username";

            var parameters = new DynamicParameters();
            parameters.Add("username", username, DbType.String);

            using var connection = _dataAccessor.CreateConnection();
            var storedPassword = await connection.QueryAsync<string>(query, parameters);

            return storedPassword.SingleOrDefault();
        }
    }
}
