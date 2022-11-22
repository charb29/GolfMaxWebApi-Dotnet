using Dapper;
using GolfMaxWebApi.Context;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GolfMaxWebApi.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly GolfMaxDbContext _context;

        public UserRepository(GolfMaxDbContext context)
        {
            _context = context;
        }

        //public async Task<List<User>> FindAll()
        //{
        //    var connection = _context.Database.GetDbConnection();

        //    try
        //    {
        //        await connection.OpenAsync();
        //        const string query = "SELECT * FROM users";

        //        var users = await connection.QueryAsync<User>(query);
        //        return users.ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    finally
        //    {
        //        await connection.CloseAsync();
        //    }
        //}

        //public async Task<User> FindByUserId(int id)
        //{
        //    var connection = _context.Database.GetDbConnection();

        //    try
        //    {
        //        await connection.OpenAsync();
        //        var query = $"SELECT * FROM users u WHERE u.id = {id}";

        //        var user = await connection.QuerySingleAsync<User>(query);
        //        return user;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    finally
        //    {
        //        await connection.CloseAsync();
        //    }
        //}

        //public async Task<User> FindByUsername(string username)
        //{
        //    var connection = _context.Database.GetDbConnection();

        //    try
        //    {
        //        await connection.OpenAsync();
        //        var query = $"SELECT * FROM users u WHERE u.username = {username}";

        //        var user = await connection.QuerySingleAsync<User>(query);
        //        return user;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    finally
        //    {
        //        await connection.CloseAsync();
        //    }
        //}

        //public async Task<User> Save(User user)
        //{
        //    var connection = _context.Database.GetDbConnection();

        //    try
        //    {
        //        await connection.OpenAsync();
        //        var query = "INSERT INTO users (username, first_name, last_name, password, email)"
        //                    + $"VALUES ('{user.Username}', '{user.FirstName}', '{user.LastName}', '{user.Password}', '{user.Email}')";

        //        var id = await connection.QueryFirstOrDefaultAsync<int>(query, user);
        //        return new User
        //        {
        //            Id = id,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            Password = user.Password,
        //            Email = user.Email
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    finally
        //    {
        //        await connection.CloseAsync();
        //    }
        //}

        //public async Task<User> Update(User user)
        //{
        //    var connection = _context.Database.GetDbConnection();

        //    try
        //    {
        //        await connection.OpenAsync();
        //        var query = $"UPDATE users u SET u.username = '{user.Username}', " +
        //                    $"u.email = '{user.Email}', u.password = '{user.Password}', " +
        //                    $"u.first_name = '{user.FirstName}', u.last_name = '{user.LastName}' " +
        //                    $"WHERE u.id = {user.Id};";
        //        return await connection.QueryFirstOrDefaultAsync<User>(query, user);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    finally
        //    {
        //        await connection.CloseAsync();
        //    }
        //}

        //public async Task DeleteById(int id)
        //{
        //    var connection = _context.Database.GetDbConnection();

        //    try
        //    {
        //        await connection.OpenAsync();
        //        var query = $"DELETE * FROM users u WHERE u.id = {id}";

        //        await connection.ExecuteAsync(query);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    finally
        //    {
        //        await connection.CloseAsync();
        //    }
        //}

        //public async Task<bool> ExistsByEmail(string email)
        //{
        //    var connection = _context.Database.GetDbConnection();

        //    try
        //    {
        //        await connection.OpenAsync();
        //        var query = $"SELECT COUNT(1) FROM users u WHERE u.email = '{email}'";

        //        return await connection.QueryFirstOrDefaultAsync<bool>(query);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    finally
        //    {
        //        await connection.CloseAsync();
        //    }
        //}

        //public async Task<bool> ExistsByUsername(string username)
        //{
        //    var connection = _context.Database.GetDbConnection();

        //    try
        //    {
        //        await connection.OpenAsync();
        //        var query = $"SELECT COUNT(1) FROM users u WHERE u.username = '{username}'";

        //        return await connection.QueryFirstOrDefaultAsync<bool>(query);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    finally
        //    {
        //        await connection.CloseAsync();
        //    }
        //}


        //public async Task<string> GetPasswordUsingUsername(string username)
        //{
        //    var connection = _context.Database.GetDbConnection();

        //    try
        //    {
        //        await connection.OpenAsync();
        //        var query = $"SELECT u.password FROM users u WHERE u.username = '{username}'";

        //        return await connection.QueryFirstOrDefaultAsync<string>(query);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    finally
        //    {
        //        await connection.CloseAsync();
        //    }
        //}
        public async Task<List<User>> FindAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Save(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetPasswordUsingUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
