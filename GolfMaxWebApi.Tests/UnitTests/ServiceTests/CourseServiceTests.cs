using GolfMaxWebApi.Models.Entities;
using Moq;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Implementations;

namespace GolfMaxWebApi.Tests.UnitTests.ServiceTests
{
    public class CourseServiceTests
    {
        [Fact]
        public async Task GetAllCourse_ShouldReturn_ListOfCourses()
        {
            var mockRepo = new Mock<ICourseRepository>();
            var expected = courses;

            mockRepo.Setup(repo => repo.FindAll())
                .ReturnsAsync(courses);

            var sut = new CourseService(mockRepo.Object);
            var actual = await sut.GetAll();

            Assert.Equal(
                expected.Select(c => c.CourseName),
                actual.Select(c => _course.CourseName)
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

            mockRepo.Setup(repo => repo.FindAll())
                .ReturnsAsync(new List<Course>());

            var sut = new CourseService(mockRepo.Object);
            var result = await sut.GetAll();

            Assert.Empty(result);
            Assert.IsType<List<Course>>(result);
        }

        [Fact]
        public async void GetCourseById_ShouldReturn_CourseWithGivenId()
        {
            var mockRepo = new Mock<ICourseRepository>();
            var expected = _course;

            mockRepo.Setup(repo => repo.FindByCourseId(expected.Id))
                .ReturnsAsync(expected);

            var sut = new CourseService(mockRepo.Object);
            var actual = await sut.GetByCourseId(_course.Id);

            Assert.Equal(expected, actual);
            Assert.Equal(expected.Id, actual?.Id);
        }

        [Fact]
        public async void GetCourseById_ShouldReturn_NullIfNoCourseIsPresent()
        {
            var mockRepo = new Mock<ICourseRepository>();

            mockRepo.Setup(repo => repo.FindByCourseId(_course.Id))
                .ReturnsAsync(value: null);

            var sut = new CourseService(mockRepo.Object);
            var result = await sut.GetByCourseId(_course.Id);

            Assert.Null(result);
        }

        [Fact]
        public async void GetCourseByCourseName_ShouldReturn_CourseWithGivenCourseName()
        {
            var mockRepo = new Mock<ICourseRepository>();
            var expected = _course;

            mockRepo.Setup(repo => repo.FindByCourseName(expected.CourseName))
                .ReturnsAsync(expected);

            var sut = new CourseService(mockRepo.Object);
            var actual = await sut.GetByCourseName(_course.CourseName);

            Assert.Equal(expected, actual);
            Assert.Equal(expected.CourseName, actual?.CourseName);
        }

        [Fact]
        public async void GetCourseByCourseName_ShouldReturn_NullIfNoCourseIsPresent()
        {
            var mockRepo = new Mock<ICourseRepository>();

            mockRepo.Setup(repo => repo.FindByCourseName(_course.CourseName))
                .ReturnsAsync(value: null);

            var sut = new CourseService(mockRepo.Object);
            var result = await sut.GetByCourseName(_course.CourseName);

            Assert.Null(result);
        }

        [Fact]
        public void CreateCourse_ShouldReturn_CreatedCourse()
        {
            throw new NotImplementedException();
        }

        private readonly Course _course = new()
        {
            Id = 1,
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
                        LayoutType = LayoutType.CHAMPIONSHIP,
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
                        LayoutType = LayoutType.MENS,
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
                        LayoutType = LayoutType.WOMEN,
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

        private readonly List<Course> courses = new List<Course>
        {
            new Course { Id = 1, CourseName = "Vista",
                HoleLayouts = new List<HoleLayout>
                {
                    new HoleLayout
                    {
                        Id = 1,
                        OverallPar = 72,
                        CourseRating = 72,
                        SlopeRating = 130,
                        Front9Yards = 2300,
                        Back9Yards = 3400,
                        LayoutType = LayoutType.CHAMPIONSHIP,
                        Holes = new List<Hole>
                        {
                            new Hole { Id = 1, HoleNumber = 1, Yards = 250, Par = 4 },
                            new Hole { Id = 2, HoleNumber = 2, Yards = 250, Par = 4 },
                            new Hole { Id = 3, HoleNumber = 3, Yards = 250, Par = 4 },
                            new Hole { Id = 4, HoleNumber = 4, Yards = 250, Par = 4 },
                            new Hole { Id = 5, HoleNumber = 5, Yards = 250, Par = 4 },
                            new Hole { Id = 6, HoleNumber = 6, Yards = 250, Par = 4 },
                            new Hole { Id = 7, HoleNumber = 7, Yards = 250, Par = 4 },
                            new Hole { Id = 8, HoleNumber = 8, Yards = 250, Par = 4 },
                            new Hole { Id = 9, HoleNumber = 9, Yards = 250, Par = 4 },
                            new Hole { Id = 10, HoleNumber = 10, Yards = 250, Par = 4 },
                            new Hole { Id = 11, HoleNumber = 11, Yards = 250, Par = 4 },
                            new Hole { Id = 12, HoleNumber = 12, Yards = 250, Par = 4 },
                            new Hole { Id = 13, HoleNumber = 13, Yards = 250, Par = 4 },
                            new Hole { Id = 14, HoleNumber = 14, Yards = 250, Par = 4 },
                            new Hole { Id = 15, HoleNumber = 15, Yards = 250, Par = 4 },
                            new Hole { Id = 16, HoleNumber = 16, Yards = 250, Par = 4 },
                            new Hole { Id = 17, HoleNumber = 17, Yards = 250, Par = 4 },
                            new Hole { Id = 18, HoleNumber = 18, Yards = 250, Par = 4 }
                        }
                    },
                    new HoleLayout
                    {
                        Id = 1,
                        OverallPar = 72,
                        CourseRating = 72,
                        SlopeRating = 130,
                        Front9Yards = 2300,
                        Back9Yards = 3400,
                        LayoutType = LayoutType.CHAMPIONSHIP,
                        Holes = new List<Hole>
                        {
                            new Hole { Id = 1, HoleNumber = 1, Yards = 250, Par = 4 },
                            new Hole { Id = 2, HoleNumber = 2, Yards = 250, Par = 4 },
                            new Hole { Id = 3, HoleNumber = 3, Yards = 250, Par = 4 },
                            new Hole { Id = 4, HoleNumber = 4, Yards = 250, Par = 4 },
                            new Hole { Id = 5, HoleNumber = 5, Yards = 250, Par = 4 },
                            new Hole { Id = 6, HoleNumber = 6, Yards = 250, Par = 4 },
                            new Hole { Id = 7, HoleNumber = 7, Yards = 250, Par = 4 },
                            new Hole { Id = 8, HoleNumber = 8, Yards = 250, Par = 4 },
                            new Hole { Id = 9, HoleNumber = 9, Yards = 250, Par = 4 },
                            new Hole { Id = 10, HoleNumber = 10, Yards = 250, Par = 4 },
                            new Hole { Id = 11, HoleNumber = 11, Yards = 250, Par = 4 },
                            new Hole { Id = 12, HoleNumber = 12, Yards = 250, Par = 4 },
                            new Hole { Id = 13, HoleNumber = 13, Yards = 250, Par = 4 },
                            new Hole { Id = 14, HoleNumber = 14, Yards = 250, Par = 4 },
                            new Hole { Id = 15, HoleNumber = 15, Yards = 250, Par = 4 },
                            new Hole { Id = 16, HoleNumber = 16, Yards = 250, Par = 4 },
                            new Hole { Id = 17, HoleNumber = 17, Yards = 250, Par = 4 },
                            new Hole { Id = 18, HoleNumber = 18, Yards = 250, Par = 4 }
                        }
                    },
                    new HoleLayout
                    {
                        Id = 1,
                        OverallPar = 72,
                        CourseRating = 72,
                        SlopeRating = 130,
                        Front9Yards = 2300,
                        Back9Yards = 3400,
                        LayoutType = LayoutType.CHAMPIONSHIP,
                        Holes = new List<Hole>
                        {
                            new Hole { Id = 1, HoleNumber = 1, Yards = 250, Par = 4 },
                            new Hole { Id = 2, HoleNumber = 2, Yards = 250, Par = 4 },
                            new Hole { Id = 3, HoleNumber = 3, Yards = 250, Par = 4 },
                            new Hole { Id = 4, HoleNumber = 4, Yards = 250, Par = 4 },
                            new Hole { Id = 5, HoleNumber = 5, Yards = 250, Par = 4 },
                            new Hole { Id = 6, HoleNumber = 6, Yards = 250, Par = 4 },
                            new Hole { Id = 7, HoleNumber = 7, Yards = 250, Par = 4 },
                            new Hole { Id = 8, HoleNumber = 8, Yards = 250, Par = 4 },
                            new Hole { Id = 9, HoleNumber = 9, Yards = 250, Par = 4 },
                            new Hole { Id = 10, HoleNumber = 10, Yards = 250, Par = 4 },
                            new Hole { Id = 11, HoleNumber = 11, Yards = 250, Par = 4 },
                            new Hole { Id = 12, HoleNumber = 12, Yards = 250, Par = 4 },
                            new Hole { Id = 13, HoleNumber = 13, Yards = 250, Par = 4 },
                            new Hole { Id = 14, HoleNumber = 14, Yards = 250, Par = 4 },
                            new Hole { Id = 15, HoleNumber = 15, Yards = 250, Par = 4 },
                            new Hole { Id = 16, HoleNumber = 16, Yards = 250, Par = 4 },
                            new Hole { Id = 17, HoleNumber = 17, Yards = 250, Par = 4 },
                            new Hole { Id = 18, HoleNumber = 18, Yards = 250, Par = 4 }
                        }
                    }
                }
            },
            new Course { Id = 1, CourseName = "Vista",
                HoleLayouts = new List<HoleLayout>
                {
                    new HoleLayout
                    {
                        Id = 1,
                        OverallPar = 72,
                        CourseRating = 72,
                        SlopeRating = 130,
                        Front9Yards = 2300,
                        Back9Yards = 3400,
                        LayoutType = LayoutType.CHAMPIONSHIP,
                        Holes = new List<Hole>
                        {
                            new Hole { Id = 1, HoleNumber = 1, Yards = 250, Par = 4 },
                            new Hole { Id = 2, HoleNumber = 2, Yards = 250, Par = 4 },
                            new Hole { Id = 3, HoleNumber = 3, Yards = 250, Par = 4 },
                            new Hole { Id = 4, HoleNumber = 4, Yards = 250, Par = 4 },
                            new Hole { Id = 5, HoleNumber = 5, Yards = 250, Par = 4 },
                            new Hole { Id = 6, HoleNumber = 6, Yards = 250, Par = 4 },
                            new Hole { Id = 7, HoleNumber = 7, Yards = 250, Par = 4 },
                            new Hole { Id = 8, HoleNumber = 8, Yards = 250, Par = 4 },
                            new Hole { Id = 9, HoleNumber = 9, Yards = 250, Par = 4 },
                            new Hole { Id = 10, HoleNumber = 10, Yards = 250, Par = 4 },
                            new Hole { Id = 11, HoleNumber = 11, Yards = 250, Par = 4 },
                            new Hole { Id = 12, HoleNumber = 12, Yards = 250, Par = 4 },
                            new Hole { Id = 13, HoleNumber = 13, Yards = 250, Par = 4 },
                            new Hole { Id = 14, HoleNumber = 14, Yards = 250, Par = 4 },
                            new Hole { Id = 15, HoleNumber = 15, Yards = 250, Par = 4 },
                            new Hole { Id = 16, HoleNumber = 16, Yards = 250, Par = 4 },
                            new Hole { Id = 17, HoleNumber = 17, Yards = 250, Par = 4 },
                            new Hole { Id = 18, HoleNumber = 18, Yards = 250, Par = 4 }
                        }
                    },
                    new HoleLayout
                    {
                        Id = 1,
                        OverallPar = 72,
                        CourseRating = 72,
                        SlopeRating = 130,
                        Front9Yards = 2300,
                        Back9Yards = 3400,
                        LayoutType = LayoutType.CHAMPIONSHIP,
                        Holes = new List<Hole>
                        {
                            new Hole { Id = 1, HoleNumber = 1, Yards = 250, Par = 4 },
                            new Hole { Id = 2, HoleNumber = 2, Yards = 250, Par = 4 },
                            new Hole { Id = 3, HoleNumber = 3, Yards = 250, Par = 4 },
                            new Hole { Id = 4, HoleNumber = 4, Yards = 250, Par = 4 },
                            new Hole { Id = 5, HoleNumber = 5, Yards = 250, Par = 4 },
                            new Hole { Id = 6, HoleNumber = 6, Yards = 250, Par = 4 },
                            new Hole { Id = 7, HoleNumber = 7, Yards = 250, Par = 4 },
                            new Hole { Id = 8, HoleNumber = 8, Yards = 250, Par = 4 },
                            new Hole { Id = 9, HoleNumber = 9, Yards = 250, Par = 4 },
                            new Hole { Id = 10, HoleNumber = 10, Yards = 250, Par = 4 },
                            new Hole { Id = 11, HoleNumber = 11, Yards = 250, Par = 4 },
                            new Hole { Id = 12, HoleNumber = 12, Yards = 250, Par = 4 },
                            new Hole { Id = 13, HoleNumber = 13, Yards = 250, Par = 4 },
                            new Hole { Id = 14, HoleNumber = 14, Yards = 250, Par = 4 },
                            new Hole { Id = 15, HoleNumber = 15, Yards = 250, Par = 4 },
                            new Hole { Id = 16, HoleNumber = 16, Yards = 250, Par = 4 },
                            new Hole { Id = 17, HoleNumber = 17, Yards = 250, Par = 4 },
                            new Hole { Id = 18, HoleNumber = 18, Yards = 250, Par = 4 }
                        }
                    },
                    new HoleLayout
                    {
                        Id = 1,
                        OverallPar = 72,
                        CourseRating = 72,
                        SlopeRating = 130,
                        Front9Yards = 2300,
                        Back9Yards = 3400,
                        LayoutType = LayoutType.CHAMPIONSHIP,
                        Holes = new List<Hole>
                        {
                            new Hole { Id = 1, HoleNumber = 1, Yards = 250, Par = 4 },
                            new Hole { Id = 2, HoleNumber = 2, Yards = 250, Par = 4 },
                            new Hole { Id = 3, HoleNumber = 3, Yards = 250, Par = 4 },
                            new Hole { Id = 4, HoleNumber = 4, Yards = 250, Par = 4 },
                            new Hole { Id = 5, HoleNumber = 5, Yards = 250, Par = 4 },
                            new Hole { Id = 6, HoleNumber = 6, Yards = 250, Par = 4 },
                            new Hole { Id = 7, HoleNumber = 7, Yards = 250, Par = 4 },
                            new Hole { Id = 8, HoleNumber = 8, Yards = 250, Par = 4 },
                            new Hole { Id = 9, HoleNumber = 9, Yards = 250, Par = 4 },
                            new Hole { Id = 10, HoleNumber = 10, Yards = 250, Par = 4 },
                            new Hole { Id = 11, HoleNumber = 11, Yards = 250, Par = 4 },
                            new Hole { Id = 12, HoleNumber = 12, Yards = 250, Par = 4 },
                            new Hole { Id = 13, HoleNumber = 13, Yards = 250, Par = 4 },
                            new Hole { Id = 14, HoleNumber = 14, Yards = 250, Par = 4 },
                            new Hole { Id = 15, HoleNumber = 15, Yards = 250, Par = 4 },
                            new Hole { Id = 16, HoleNumber = 16, Yards = 250, Par = 4 },
                            new Hole { Id = 17, HoleNumber = 17, Yards = 250, Par = 4 },
                            new Hole { Id = 18, HoleNumber = 18, Yards = 250, Par = 4 }
                        }
                    }
                }
            },
        };
    }
}