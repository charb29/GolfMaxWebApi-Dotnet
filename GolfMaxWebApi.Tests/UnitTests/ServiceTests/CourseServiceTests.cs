using GolfMaxWebApi.Models.Entities;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Implementations;

namespace GolfMaxWebApi.Tests.UnitTests.ServiceTests
{
    public class CourseServiceTests
    {
        [Fact]
        public void GetAllCourse_ShouldReturn_ListOfCourses()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetAllCourses_ShouldReturn_NullIfNonePresent()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetCourseById_ShouldReturn_CourseWithGivenId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetCourseById_ShouldReturn_NullIfNoCourseIsPresent()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetCourseByCourseName_ShouldReturn_CourseWithGivenId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetCourseByCourseName_ShouldReturn_NullIfNoCourseIsPresent()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void CreateCouse_ShouldReturn_CreatedCourse()
        {
            throw new NotImplementedException();
        }

        private Course GetCourse()
        {
            return new Course
            {
                Id = 1,
                CourseName = "Vista Valencia",
                HoleLayouts = new List<HoleLayout>()
                {
                    new HoleLayout
                    {
                        Id = 1,
                        Front9Yards = 3400,
                        Back9Yards = 2750,
                        CourseRating = 70.4,
                        SlopeRating = 120.5,
                        OverallPar = 72,
                        LayoutType = LayoutType.CHAMPIONSHIP,
                        Holes = new List<Hole>
                        {
                            new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                            new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                        }
                    },
                    new HoleLayout
                    {
                        Id = 2,
                        Front9Yards = 3400,
                        Back9Yards = 2750,
                        CourseRating = 70.4,
                        SlopeRating = 120.5,
                        OverallPar = 72,
                        LayoutType = LayoutType.MENS,
                        Holes = new List<Hole>
                        {
                            new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                            new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                        }
                    },
                    new HoleLayout
                    {
                        Id = 3,
                        Front9Yards = 3400,
                        Back9Yards = 2750,
                        CourseRating = 70.4,
                        SlopeRating = 120.5,
                        OverallPar = 72,
                        LayoutType = LayoutType.WOMEN,
                        Holes = new List<Hole>
                        {
                            new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                            new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                            new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                        }
                    }
                }
            };
        }

        private List<Course> CourseList()
        {
            return new List<Course>()
            {
                new Course { Id = 1, CourseName = "Vista Valencia", HoleLayouts = new List<HoleLayout>()
                    {
                        new HoleLayout
                        {
                            Id = 1,
                            Front9Yards = 3400,
                            Back9Yards = 2750,
                            CourseRating = 70.4,
                            SlopeRating = 120.5,
                            OverallPar = 72,
                            LayoutType = LayoutType.CHAMPIONSHIP,
                            Holes = new List<Hole>
                            {
                                new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                                new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                            }
                        },
                        new HoleLayout
                        {
                            Id = 2,
                            Front9Yards = 3400,
                            Back9Yards = 2750,
                            CourseRating = 70.4,
                            SlopeRating = 120.5,
                            OverallPar = 72,
                            LayoutType = LayoutType.MENS,
                            Holes = new List<Hole>
                            {
                                new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                                new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                            }
                        },
                        new HoleLayout
                        {
                            Id = 3,
                            Front9Yards = 3400,
                            Back9Yards = 2750,
                            CourseRating = 70.4,
                            SlopeRating = 120.5,
                            OverallPar = 72,
                            LayoutType = LayoutType.WOMEN,
                            Holes = new List<Hole>
                            {
                                new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                                new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                            }
                        }
                    }
                },
                new Course { Id = 2, CourseName = "Vista Valencia", HoleLayouts = new List<HoleLayout>()
                    {
                        new HoleLayout
                        {
                            Id = 4,
                            Front9Yards = 3400,
                            Back9Yards = 2750,
                            CourseRating = 70.4,
                            SlopeRating = 120.5,
                            OverallPar = 72,
                            LayoutType = LayoutType.CHAMPIONSHIP,
                            Holes = new List<Hole>
                            {
                                new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                                new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                            }
                        },
                        new HoleLayout
                        {
                            Id = 5,
                            Front9Yards = 3400,
                            Back9Yards = 2750,
                            CourseRating = 70.4,
                            SlopeRating = 120.5,
                            OverallPar = 72,
                            LayoutType = LayoutType.MENS,
                            Holes = new List<Hole>
                            {
                                new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                                new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                            }
                        },
                        new HoleLayout
                        {
                            Id = 6,
                            Front9Yards = 3400,
                            Back9Yards = 2750,
                            CourseRating = 70.4,
                            SlopeRating = 120.5,
                            OverallPar = 72,
                            LayoutType = LayoutType.WOMEN,
                            Holes = new List<Hole>
                            {
                                new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                                new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                            }
                        }
                    }
                },
                    new Course { Id = 3, CourseName = "Vista Valencia", HoleLayouts = new List<HoleLayout>()
                    {
                        new HoleLayout
                        {
                            Id = 7,
                            Front9Yards = 3400,
                            Back9Yards = 2750,
                            CourseRating = 70.4,
                            SlopeRating = 120.5,
                            OverallPar = 72,
                            LayoutType = LayoutType.CHAMPIONSHIP,
                            Holes = new List<Hole>
                            {
                                new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                                new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                            }
                        },
                        new HoleLayout
                        {
                            Id = 8,
                            Front9Yards = 3400,
                            Back9Yards = 2750,
                            CourseRating = 70.4,
                            SlopeRating = 120.5,
                            OverallPar = 72,
                            LayoutType = LayoutType.MENS,
                            Holes = new List<Hole>
                            {
                                new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                                new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                            }
                        },
                        new HoleLayout
                        {
                            Id = 9,
                            Front9Yards = 3400,
                            Back9Yards = 2750,
                            CourseRating = 70.4,
                            SlopeRating = 120.5,
                            OverallPar = 72,
                            LayoutType = LayoutType.WOMEN,
                            Holes = new List<Hole>
                            {
                                new Hole { Par = 4, HoleNumber = 1, Yards = 450 },
                                new Hole { Par = 3, HoleNumber = 2, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 3, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 4, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 5, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 6, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 7, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 8, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 9, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 10, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 11, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 12, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 13, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 14, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 15, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 16, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 17, Yards = 300 },
                                new Hole { Par = 3, HoleNumber = 18, Yards = 300 },
                            }
                        }
                    }
                }
            };
        }
    }
}