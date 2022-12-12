using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GolfMaxWebApi.Controllers;

[ApiController]
[Route("golfmax/[controller]")]
public class CourseController : Controller
{
    private readonly ICourseService _courseService;
    private readonly ILogger<CourseController> _logger;

    public CourseController(ICourseService courseService, ILogger<CourseController> logger)
    {
        _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
    {
        try
        {
            var courses = await _courseService.GetAllAsync();

            if (courses is null) 
                return NoContent();

            return Ok(courses);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error retrieving all courses - Type: {ex}", ex.GetType());
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
    public async Task<ActionResult> GetCourseById(int id)
    {
        try
        {
            var retrievedCourse = await _courseService.GetByCourseIdAsync(id);

            if (retrievedCourse is null)
                return new ObjectResult(
                    new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Type = $"https://localhost:7051/swagger/golfmax/Course/{id}",
                        Title = "Course not found",
                        Detail = $"Course not found using id: {id}",
                        Instance = HttpContext.Request.Path
                    }
                );
            
            return Ok(retrievedCourse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception caught retrieving user by id - Type: {ex}", ex.GetType());
            _logger.LogError("Source: {ex}", ex.Source);
            _logger.LogError("StackTrace: {ex}", ex.StackTrace);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public Task<ActionResult> UpdateCourse(int id, Course course)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult> DeleteCourse(int id)
    {
        try
        {
            var course = await _courseService.GetByCourseIdAsync(id);

            if (course is null)
                return new ObjectResult(
                    new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Type = $"https://localhost:7051/swagger/golfmax/Course/{id}",
                        Title = "Course not found",
                        Detail = $"Course not found using id: {id}",
                        Instance = HttpContext.Request.Path
                    }
                );
            

            await _courseService.DeleteByIdAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception caught attempting to delete course using Type: {ex}", ex.GetType());
            _logger.LogError("Source: {ex}", ex.Source);
            _logger.LogError("StackTrace: {ex}", ex.StackTrace);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("new")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<Course>> AddCourse(Course course)
    {
        try
        {
            var existingCourse = await _courseService.IsCourseAlreadyCreatedAsync(course);

            if (!existingCourse)
                return new ObjectResult(
                    new ProblemDetails
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Type = "https://localhost:7051/swagger/golfmax/Course/new",
                        Title = "Invalid Credentials",
                        Detail = "Course with given information already exists within the database.",
                        Instance = HttpContext.Request.Path
                    }
                );

            var createdCourse = await _courseService.CreateCourseAsync(course);
            return StatusCode(StatusCodes.Status201Created, createdCourse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception caught attempting to create new course - Type: {ex}", ex.GetType());
            _logger.LogError("Source: {ex}", ex.Source);
            _logger.LogError("StackTrace: {ex}", ex.StackTrace);
            return StatusCode(500, ex.Message);
        }
    }
}