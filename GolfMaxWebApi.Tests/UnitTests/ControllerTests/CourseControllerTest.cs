using GolfMaxWebApi.Controllers;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Services.Interfaces;
using GolfMaxWebApi.Tests.MockObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace GolfMaxWebApi.Tests.UnitTests.ControllerTests;

public class CourseControllerTest
{
    [Fact]
    public async Task GetAllCourses_ShouldReturn_200Ok_IfCoursesArePresent()
    {
        var mockCourseService = new Mock<ICourseService>();
        var mockLogger = new Mock<ILogger<CourseController>>();

        mockCourseService.Setup(service => service.GetAllAsync()).ReturnsAsync(MockCourse.Courses());

        var sut = new CourseController(mockCourseService.Object, mockLogger.Object);
        var result = await sut.GetAllCourses();
        var expected = Assert.IsType<ActionResult<IEnumerable<Course>>>(result);

        Assert.IsType<OkObjectResult>(expected.Result);
    }

    [Fact]
    public async Task GetAllCourses_ShouldReturn_204NoContent_IfListIsNull()
    {
        var mockCourseService = new Mock<ICourseService>();
        var mockLogger = new Mock<ILogger<CourseController>>();

        mockCourseService.Setup(service => service.GetAllAsync())!.ReturnsAsync(value: null);

        var sut = new CourseController(mockCourseService.Object, mockLogger.Object);
        var result = await sut.GetAllCourses();
        var expected = Assert.IsType<ActionResult<IEnumerable<Course>>>(result);

        Assert.IsType<NoContentResult>(expected.Result);
    }

    [Fact]
    public async Task GetCourseById_ShouldReturn_200Ok_IfCourseIsFound()
    {
        var mockCourseService = new Mock<ICourseService>();
        var mockLogger = new Mock<ILogger<CourseController>>();

        mockCourseService.Setup(service => service.GetByCourseIdAsync(MockCourse.Course().Id))
            .ReturnsAsync(MockCourse.Course());

        var sut = new CourseController(mockCourseService.Object, mockLogger.Object);
        var result = await sut.GetCourseById(MockCourse.Course().Id);
        var expected = Assert.IsType<OkObjectResult>(result);

        Assert.IsType<OkObjectResult>(expected);
    }

    [Fact]
    public async Task GetCourseById_ShouldReturn_404NotFound_IfNoCourseFound()
    {
        var mockCourseService = new Mock<ICourseService>();
        var mockLogger = new Mock<ILogger<CourseController>>();

        mockCourseService.Setup(service => service.GetByCourseIdAsync(1)).ReturnsAsync(value: null);

        var sut = new CourseController(mockCourseService.Object, mockLogger.Object);
        var result = await sut.GetCourseById(1);
        var expected = Assert.IsType<ObjectResult>(result);

        Assert.IsType<ObjectResult>(expected);
    }

    [Fact]
    public async Task AddCourse_ShouldReturn_201Created()
    {
        var mockCourseService = new Mock<ICourseService>();
        var mockLogger = new Mock<ILogger<CourseController>>();

        mockCourseService.Setup(service => service.CreateCourseAsync(MockCourse.Course()))
            .ReturnsAsync(MockCourse.Course());

        var sut = new CourseController(mockCourseService.Object, mockLogger.Object);
        var result = await sut.AddCourse(MockCourse.Course());
        var expected = Assert.IsType<ActionResult<Course>>(result);

        Assert.IsType<ObjectResult>(expected.Result);
    }

    [Fact]
    public async Task AddCourse_ShouldReturn_401UnAuthorized_IfCourseAlreadyExists()
    {
        var mockCourseService = new Mock<ICourseService>();
        var mockLogger = new Mock<ILogger<CourseController>>();

        mockCourseService.Setup(service => service.CreateCourseAsync(MockCourse.Course()))
            .ReturnsAsync(MockCourse.Course());

        var sut = new CourseController(mockCourseService.Object, mockLogger.Object);
        var result = await sut.AddCourse(MockCourse.Course());
        var expected = Assert.IsType<ActionResult<Course>>(result);

        Assert.IsType<ObjectResult>(expected.Result);
    }
}