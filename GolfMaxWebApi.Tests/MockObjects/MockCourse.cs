using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Tests.MockObjects;
public static class MockCourse
{

    public static Course Course()
    {
        return new Course
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

    public static List<Course> Courses()
    {
        return new List<Course>
        {
            new Course
            {
                Id = 1,
                CourseName = "Vista",
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
                        LayoutType = LayoutType.Championship,
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
                        LayoutType = LayoutType.Championship,
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
                        LayoutType = LayoutType.Championship,
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
            new Course
            {
                Id = 1, CourseName = "Vista",
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
                        LayoutType = LayoutType.Championship,
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
                        LayoutType = LayoutType.Championship,
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
                        LayoutType = LayoutType.Championship,
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
            }
        };
    }

    public static HoleLayout HoleLayout()
    {
        return new HoleLayout
        {
            Id = 1,
            Front9Yards = 3000,
            Back9Yards = 5000,
            OverallPar = 72,
            CourseRating = 71.0,
            SlopeRating = 120.2,
            LayoutType = LayoutType.Championship,
            CourseId = 1,
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
        };
    }

    public static List<HoleLayout> HoleLayouts()
    {
        return new List<HoleLayout>
        {
            new HoleLayout()
            {
                Id = 1,
                Front9Yards = 3000,
                Back9Yards = 5000,
                OverallPar = 72,
                CourseRating = 71.0,
                SlopeRating = 120.2,
                LayoutType = LayoutType.Championship,
                CourseId = 1,
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
            new HoleLayout()
            {
                Id = 1,
                Front9Yards = 3000,
                Back9Yards = 5000,
                OverallPar = 72,
                CourseRating = 71.0,
                SlopeRating = 120.2,
                LayoutType = LayoutType.Mens,
                CourseId = 1,
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
        };
    }

    public static Hole Hole()
    {
        return new Hole
        {
            Id = 1,
            Par = 5,
            Yards = 540,
            HoleNumber = 3
        };
    }
    
    public static List<Hole> Holes()
    {
        return new List<Hole>
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
        };
    }
}

