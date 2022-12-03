using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Interfaces;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GolfMaxWebApi.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository userRepository)
    {
        _repository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _repository.FindAllAsync();
        return users;
    }

    public async Task<User> UpdateAsync(User user, int id)
    {
        await _repository.UpdateAsync(user, id);
        return user;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _repository.FindByUserIdAsync(id);
        return user;
    }

    public async Task<User> CreateAsync(User user)
    {
        var createdUser = await _repository.SaveAsync(user);
        return createdUser;
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
    }

    public async Task<bool> IsValidLoginRequestAsync(User user)
    {
        var username = user.Username;

        if (username is null)
            throw new ArgumentNullException(nameof(user));

        var storedUser = await _repository.FindByUsernameAsync(username);

        return user.Password == storedUser?.Password;
    }

    public async Task<bool> IsValidRegistrationRequestAsync(User user)
    {
        var validEmailFormat = IsValidEmailFormat(user.Email);
        if (!validEmailFormat) return false;

        var storedUser = await _repository.FindExistingUserAsync(user);

        return storedUser == null;
    }

    private static bool IsValidEmailFormat(string email)
    {
        if (email == null)
            throw new ArgumentNullException(nameof(email));

        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            email = Regex.Replace(
                email,
                "(@)(.+)$",
                DomainMapper,
                RegexOptions.None,
                TimeSpan.FromMilliseconds(200)
            );

            static string DomainMapper(Match match)
            {
                var idnMapping = new IdnMapping();
                var domainName = idnMapping.GetAscii(match.Groups[2].Value);
                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }
        try
        {
            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(250)
            );
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}