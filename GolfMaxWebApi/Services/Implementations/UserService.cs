using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Interfaces;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GolfMaxWebApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _repository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            _logger.LogInformation("Starting method 'GetAllUsers'");

            var users = await _repository.FindAll();
            return users;
        }

        public async Task Update(User userRequest, int id)
        {
            _logger.LogInformation("Starting method 'Update'");
            await _repository.Update(userRequest, id);
        }

        public async Task<User?> GetById(int id)
        {
            _logger.LogInformation("Starting method 'Update' with Id {id}", id);
            var user = await _repository.FindByUserId(id);
            return user;
        }

        public async Task<User> Create(User user)
        {
            _logger.LogInformation("Starting method 'Create' with user {user}", user);
            await _repository.Save(user);
            return user;
        }

        public async Task DeleteById(int id)
        {
            _logger.LogInformation("Deleting user using Id {id}", id);
            await _repository.DeleteById(id);
        }

        public async Task<bool> IsValidLoginRequest(User user)
        {
            _logger.LogInformation("Starting method 'IsValidLoginRequest' with user {user}", user);
            string username = user.Username;

            if (username is null)
                throw new ArgumentNullException(nameof(username));

            var storedUser = await _repository.FindByUsername(username);

            return user?.Password == storedUser?.Password;
        }

        public async Task<bool> IsValidRegistrationRequest(User user)
        {
            var validEmailFormat = IsValidEmailFormat(user.Email);
            if (!validEmailFormat) return false;

            var storedUser = await _repository.FindExistingUser(user);

            if (storedUser is null)
                return true;
            else
                return false;
        }

        private bool IsValidEmailFormat(string email)
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
                    string domainName = idnMapping.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException ex)
            {
                _logger.LogError("Regex Match Timeout Exception {ex}", ex);
                return false;
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("Argument Exception {ex}", ex);
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
}
