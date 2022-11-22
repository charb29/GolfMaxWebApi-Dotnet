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

        public async Task<List<User>> GetAll()
        {
            _logger.LogInformation("Starting method 'GetAllUsers'");
            return await _repository.FindAll();
        }

        public async Task<User> Update(User userRequest, int id)
        {
            _logger.LogInformation("Starting method 'Update'");
            var user = await _repository.FindByUserId(id);

            user.FirstName = userRequest.FirstName;
            user.LastName = userRequest.LastName;
            user.Username = userRequest.Username;
            user.Password = userRequest.Password;
            user.Email = userRequest.Email;

            return await _repository.Update(user);
        }

        public async Task<User> GetById(int id)
        {
            _logger.LogInformation("Starting method 'Update' with Id {id}", id);
            return await _repository.FindByUserId(id);
        }

        public async Task<User> Create(User user)
        {
            _logger.LogInformation("Starting method 'Create' with user {user}", user);
            return await _repository.Save(user);
        }

        public async Task DeleteById(int id)
        {
            _logger.LogInformation("Deleting user using Id {id}", id);
            await _repository.DeleteById(id);
        }

        public async Task<bool> IsValidUsername(string username)
        {
            return await _repository.ExistsByUsername(username);
        }

        public async Task<bool> IsValidEmail(string email)
        {
            _logger.LogInformation("Querying email {email} from database", email);
            return await _repository.ExistsByEmail(email);
        }

        public async Task<bool> IsValidLoginRequest(User user)
        {
            _logger.LogInformation("Starting method 'IsValidLoginRequest' with user {user}", user);

            if (user.Username == null)
                throw new ArgumentNullException(nameof(user));

            bool usernameIsValid = await _repository.ExistsByUsername(user.Username);

            if (!usernameIsValid)
            {
                return false;
            }
            else
            {
                string password = await _repository.GetPasswordUsingUsername(user.Username);

                _logger.LogInformation(
                    "Retrieving user password {password} using username {username}",
                    password,
                    user.Username
                );

                return user.Password == password;
            }
        }

        public async Task<bool> IsValidRegistrationRequest(User user)
        {
            _logger.LogWarning(
                "Username {user.Username} and Email {user.Email} might be null.",
                user.Username,
                user.Email
            );
            string username = user.Username ?? throw new ArgumentNullException(nameof(user));
            string email = user.Email ?? throw new ArgumentNullException(nameof(user));

            _logger.LogInformation(
                "Validating username {username} and email {email} for Registration Request",
                username,
                email
            );
            bool usernameIsTaken = await UsernameExists(username);
            bool emailIsTaken = await EmailExists(email);

            return !usernameIsTaken && !emailIsTaken && IsValidEmailFormat(email);
        }

        private async Task<bool> UsernameExists(string username)
        {
            return await _repository.ExistsByUsername(username);
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _repository.ExistsByEmail(email);
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
