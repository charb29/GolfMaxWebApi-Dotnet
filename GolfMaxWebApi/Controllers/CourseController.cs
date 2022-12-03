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
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<CourseDto>> GetCourseById(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<CourseDto>> UpdateCourse(int id, CourseDto courseDto)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult> DeleteCourse(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("new-course")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<CourseDto>> AddCourse(CourseDto courseDto)
    {
        throw new NotImplementedException();
    }
}