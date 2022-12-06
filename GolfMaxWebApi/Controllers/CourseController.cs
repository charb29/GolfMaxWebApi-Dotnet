using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Mappers.Interfaces;
using GolfMaxWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GolfMaxWebApi.Controllers;

[ApiController]
[Route("golfmax/[controller]")]
public class CourseController : Controller
{
    private readonly ICourseService _courseService;
    private readonly ICourseMapper _courseMapper;
    private readonly ILogger<CourseController> _logger;

    public CourseController(ICourseService courseService, 
                            ICourseMapper courseMapper,
                            ILogger<CourseController> logger)
    {
        _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
        _courseMapper = courseMapper;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses()
    {
        try
        {
            var courses = await _courseService.GetAllAsync();

            if (courses is null) 
                return NoContent();

            var courseResponse = _courseMapper.ConvertToCourseDtoList(courses);
            return Ok(courseResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error retrieving all courses: {ex}", ex);
            return StatusCode(500, ex);
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
            
            var courseResponse = _courseMapper.ConvertToCourseDto(course);
            return Ok(courseResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception {ex} thrown retrieving course using id: {id}", ex, id);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public Task<ActionResult> UpdateCourse(int id, CourseDto courseDto)
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
            _logger.LogError("Exception {ex} caught attempting to delete course using id: {id}", ex, id);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("new")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<CourseDto>> AddCourse(CourseDto courseDto)
    {
        try
        {
            var course = _courseMapper.ConvertToCourseEntity(courseDto);
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
            var courseResponse = _courseMapper.ConvertToCourseDto(createdCourse);
            return StatusCode(StatusCodes.Status201Created, courseResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception {ex} caught attempting to create new course", ex);
            return StatusCode(500, ex.Message);
        }
    }
}