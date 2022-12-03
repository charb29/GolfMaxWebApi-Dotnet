using GolfMaxWebApi.Models.Entities;
using Moq;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Implementations;
using GolfMaxWebApi.Tests.MockObjects;

namespace GolfMaxWebApi.Tests.UnitTests.ServiceTests;

public class CourseServiceTests
{
    [Fact]
    public async Task GetAllCourse_ShouldReturn_ListOfCourses()
    {
        var mockRepo = new Mock<ICourseRepository>();
        var expected = MockCourse.Courses();

        mockRepo.Setup(repo => repo.FindAllAsync())
            .ReturnsAsync(MockCourse.Courses());

        var sut = new CourseService(mockRepo.Object);
        var actual = await sut.GetAllAsync();

        Assert.Equal(
            expected.Select(c => c.CourseName),
            actual.Select(c => c.CourseName)
        );
        Assert.Equal(
            expected.Select(c => c.HoleLayouts.Count),
            actual.Select(c => c.HoleLayouts.Count)
        );
        Assert.Equal(
            expected.Select(c => c.HoleLayouts.Select(
                holeLayouts => holeLayouts.Holes.Count)),
            actual.Select(c => c.HoleLayouts.Select(
                holeLayouts => holeLayouts.Holes.Count))
        );
        Assert.IsType<List<Course>>(actual);
    }

    [Fact]
    public async void GetAllCourses_ShouldReturn_EmptyListIfNonePresent()
    {
        var mockRepo = new Mock<ICourseRepository>();

        mockRepo.Setup(repo => repo.FindAllAsync())
            .ReturnsAsync(new List<Course>());

        var sut = new CourseService(mockRepo.Object);
        var result = await sut.GetAllAsync();

        Assert.Empty(result);
        Assert.IsType<List<Course>>(result);
    }

    [Fact]
    public async void GetCourseById_ShouldReturn_CourseWithGivenId()
    {
        var mockRepo = new Mock<ICourseRepository>();
        var expected = MockCourse.Course();

        mockRepo.Setup(repo => repo.FindByCourseIdAsync(expected.Id))
            .ReturnsAsync(expected);

        var sut = new CourseService(mockRepo.Object);
        var actual = await sut.GetByCourseIdAsync(MockCourse.Course().Id);

        Assert.Equal(expected, actual);
        Assert.Equal(expected.Id, actual?.Id);
        Assert.Equal(expected.CourseName, actual?.CourseName);
    }

    [Fact]
    public async void GetCourseById_ShouldReturn_NullIfNoCourseIsPresent()
    {
        var mockRepo = new Mock<ICourseRepository>();

        mockRepo.Setup(repo => repo.FindByCourseIdAsync(MockCourse.Course().Id))
            .ReturnsAsync(value: null);

        var sut = new CourseService(mockRepo.Object);
        var result = await sut.GetByCourseIdAsync(MockCourse.Course().Id);

        Assert.Null(result);
    }

    [Fact]
    public async void GetCourseByCourseName_ShouldReturn_CourseWithGivenCourseName()
    {
        var mockRepo = new Mock<ICourseRepository>();
        var expected = MockCourse.Course();

        mockRepo.Setup(repo => repo.FindByCourseNameAsync(expected.CourseName))
            .ReturnsAsync(expected);

        var sut = new CourseService(mockRepo.Object);
        var actual = await sut.GetByCourseNameAsync(MockCourse.Course().CourseName);

        Assert.Equal(expected, actual);
        Assert.Equal(expected.CourseName, actual?.CourseName);
    }

    [Fact]
    public async void GetCourseByCourseName_ShouldReturn_NullIfNoCourseIsPresent()
    {
        var mockRepo = new Mock<ICourseRepository>();

        mockRepo.Setup(repo => repo.FindByCourseNameAsync(MockCourse.Course().CourseName))
            .ReturnsAsync(value: null);

        var sut = new CourseService(mockRepo.Object);
        var result = await sut.GetByCourseNameAsync(MockCourse.Course().CourseName);

        Assert.Null(result);
    }

    [Fact]
    public async Task CreateCourse_ShouldReturn_CreatedCourse()
    {
        var mockRepo = new Mock<ICourseRepository>();
        var expected = _course;

        mockRepo.Setup(repo => repo.SaveAsync(_course)).ReturnsAsync(_course);

        var sut = new CourseService(mockRepo.Object);
        var actual = await sut.CreateCourseAsync(_course);
        
        Assert.Equal(expected, actual);
        Assert.Equal(expected.CourseName, actual.CourseName);
    }
    
    private readonly Course _course = new()
    {
        CourseName = "Vista",
        HoleLayouts = new List<HoleLayout>
            {
                new HoleLayout
                {
                    OverallPar = 72,
                    CourseRating = 72,
                    SlopeRating = 130,
                    Front9Yards = 2300,
                    Back9Yards = 3400,
                    LayoutType = LayoutType.Championship,
                    Holes = new List<Hole>
                    {
                        new Hole { HoleNumber = 1, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 2, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 3, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 4, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 5, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 6, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 7, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 8, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 9, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 10, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 11, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 12, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 13, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 14, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 15, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 16, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 17, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 18, Yards = 250, Par = 4 }
                    }
                },
                new HoleLayout
                {
                    OverallPar = 72,
                    CourseRating = 72,
                    SlopeRating = 130,
                    Front9Yards = 2300,
                    Back9Yards = 3400,
                    LayoutType = LayoutType.Mens,
                    Holes = new List<Hole>
                    {
                        new Hole { HoleNumber = 1, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 2, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 3, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 4, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 5, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 6, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 7, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 8, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 9, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 10, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 11, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 12, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 13, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 14, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 15, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 16, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 17, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 18, Yards = 250, Par = 4 }
                    }
                },
                new HoleLayout
                {
                    OverallPar = 72,
                    CourseRating = 72,
                    SlopeRating = 130,
                    Front9Yards = 2300,
                    Back9Yards = 3400,
                    LayoutType = LayoutType.Women,
                    Holes = new List<Hole>
                    {
                        new Hole { HoleNumber = 1, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 2, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 3, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 4, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 5, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 6, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 7, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 8, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 9, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 10, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 11, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 12, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 13, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 14, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 15, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 16, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 17, Yards = 250, Par = 4 },
                        new Hole { HoleNumber = 18, Yards = 250, Par = 4 }
                    }
                }
            }
    };
}