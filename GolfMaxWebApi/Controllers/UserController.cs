using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Mappers.Interfaces;
using GolfMaxWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GolfMaxWebApi.Controllers;

[ApiController]
[Route("golfmax/[controller]/")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IUserMapper _userMapper;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, 
                          IUserMapper userMapper, 
                          ILogger<UserController> logger)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _userMapper = userMapper;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
    {
        try
        {
            var users = await _userService.GetAllAsync();

            if (users is null) 
                return NoContent();

            var userResponse = _userMapper.ConvertToUserDtoList(users);
            return Ok(userResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception caught attempting to fetch all List of Users - Type: {ex}", ex.GetType());
            _logger.LogError("Source: {ex}", ex.Source);
            _logger.LogError("StackTrace: {ex}", ex.StackTrace);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);

            if (user is null)
                return new ObjectResult(
                    new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Type = $"https://localhost:7051/swagger/golfmax/User/{id}",
                        Title = "User not found",
                        Detail = $"User not found using id: {id}",
                        Instance = HttpContext.Request.Path
                    }
                );

            var userResponse = _userMapper.ConvertToUserDto(user);
            return Ok(userResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception caught retrieving User by id - Type: {ex}", ex.GetType());
            _logger.LogError("Source: {ex}", ex.Source);
            _logger.LogError("StackTrace: {ex}", ex.StackTrace);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<UserDto>> UpdateUserInfo(int id, UserDto userRequest)
    {
        try
        {
            var user = _userMapper.ConvertToEntity(userRequest);
            var isValidUpdateRequest = await _userService.IsValidUpdateRequestAsync(user);
            
            if (!isValidUpdateRequest)
                return new ObjectResult(
                    new ProblemDetails
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Type = "https://localhost:7051/swagger/golfmax/User/register",
                        Title = "Invalid Credentials",
                        Detail = "Username or email are already in use.",
                        Instance = HttpContext.Request.Path
                    }
                );
            
            var updatedUser = await _userService.UpdateAsync(user, id);
            var result = _userMapper.ConvertToUserDto(updatedUser);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception caught attempting to update user - Type: {ex}", ex.GetType());
            _logger.LogError("Source: {ex}", ex.Source);
            _logger.LogError("StackTrace: {ex}", ex.StackTrace);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult> DeleteUser(int id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);

            if (user is null)
                return new ObjectResult(
                    new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Type = $"https://localhost:7051/swagger/golfmax/User/{id}",
                        Title = "User not found",
                        Detail = $"User not found using id: {id}",
                        Instance = HttpContext.Request.Path
                    }
                );
            
            await _userService.DeleteByIdAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception caught attempting to delete user - Type: {ex}", ex.GetType());
            _logger.LogError("Source: {ex}", ex.Source);
            _logger.LogError("StackTrace: {ex}", ex.StackTrace);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<UserDto>> Login(UserDto userRequest)
    {
        try
        {
            var user = _userMapper.ConvertToEntity(userRequest);
            var isValidRequest = await _userService.IsValidLoginRequestAsync(user);

            if (!isValidRequest)
                return new ObjectResult(
                    new ProblemDetails
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Type = "https://localhost:7051/swagger/golfmax/User/login",
                        Title = "Invalid Credentials",
                        Detail = "Username or password is incorrect",
                        Instance = HttpContext.Request.Path
                    }
                );
            
            var userResponse = _userMapper.ConvertToUserDto(user);
            return Ok(userResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception caught attempting to login - Type: {ex}", ex.GetType());
            _logger.LogError("Source: {ex}", ex.Source);
            _logger.LogError("StackTrace: {ex}", ex.StackTrace);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<UserDto>> Register(UserDto userRequest)
    {
        try
        {
            var user = _userMapper.ConvertToEntity(userRequest);
            var isValidRegistrationRequest = await _userService.IsValidRegistrationRequestAsync(user);

            if (!isValidRegistrationRequest)
                return new ObjectResult(
                    new ProblemDetails
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Type = "https://localhost:7051/swagger/golfmax/User/register",
                        Title = "Invalid Credentials",
                        Detail = "Username or password are already taken.",
                        Instance = HttpContext.Request.Path
                    }
                );
            
            var createdUser = await _userService.CreateAsync(user);
            var userResponse = _userMapper.ConvertToUserDto(createdUser);
            return StatusCode(StatusCodes.Status201Created, userResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception caught attempting to create user - Type: {ex}", ex.GetType());
            _logger.LogError("Source: {ex}", ex.Source);
            _logger.LogError("StackTrace: {ex}", ex.StackTrace);
            return StatusCode(500, ex.Message);
        }
    }
}