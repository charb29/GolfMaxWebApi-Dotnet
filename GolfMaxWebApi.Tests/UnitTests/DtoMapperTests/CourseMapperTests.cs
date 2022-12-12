using GolfMaxWebApi.Models.Mappers.Implementations;
using GolfMaxWebApi.Tests.MockObjects;

namespace GolfMaxWebApi.Tests.UnitTests.DtoMapperTests;

public class CourseMapperTests
{
    [Fact]
    public void MapCourseEntityToDto_ReturnsCourseDto()
    {
        var expected = MockCourse.CourseDto();
        var sut = new CourseMapper();
        var actual = sut.ConvertToCourseDto(MockCourse.Course());

        Assert.Equal(expected.CourseName, actual.CourseName);
        Assert.Equal(
            (expected.HoleLayouts ?? throw new InvalidOperationException()).Count,
            (actual.HoleLayouts ?? throw new InvalidOperationException()).Count);
        Assert.Equal(
            expected.HoleLayouts.Select(holeLayoutDto =>
                (holeLayoutDto.HoleDtos ?? throw new InvalidOperationException()).Count),
            actual.HoleLayouts.Select(holeLayout =>
                (holeLayout.HoleDtos ?? throw new InvalidOperationException()).Count));
    }

    [Fact]
    public void MapCourseEntityToDtoList_ReturnsCourseDtoList()
    {
        var expected = MockCourse.CourseDtos();
        var sut = new CourseMapper();
        var actual = sut.ConvertToCourseDtoList(MockCourse.Courses());

        Assert.Equal(expected.Count, actual.Count);
        Assert.Equal(
            expected.Select(course => course.CourseName), 
            actual.Select(course => course.CourseName));
        Assert.Equal(
            expected.Select(course => course.HoleLayouts.Count),
            actual.Select(course => course.HoleLayouts.Count));
    }

    [Fact]
    public void MapCourseDtoToEntity_ReturnsCourseEntity()
    {
        var expected = MockCourse.Course();
        var sut = new CourseMapper();
        var actual = sut.ConvertToCourseEntity(MockCourse.CourseDto());

        Assert.Equal(expected.CourseName, actual.CourseName);
        Assert.Equal(expected.HoleLayouts.Count, actual.HoleLayouts.Count);
        Assert.Equal(
            expected.HoleLayouts.Select(holeLayout => holeLayout.Holes.Count),
            actual.HoleLayouts.Select(holeLayout => holeLayout.Holes.Count));
    }

    [Fact]
    public void MapHoleLayoutEntityToDto_ReturnsHoleLayoutDto()
    {
        var expected = MockCourse.HoleLayoutDto();
        var sut = new CourseMapper();
        var actual = sut.ConvertToHoleLayoutDto(MockCourse.HoleLayout());

        Assert.Equal(expected.Front9Yards, actual.Front9Yards);
        Assert.Equal(expected.Back9Yards, actual.Back9Yards);
        Assert.Equal(expected.CourseRating, actual.CourseRating);
        Assert.Equal(expected.SlopeRating, actual.SlopeRating);
        Assert.Equal(expected.LayoutType, actual.LayoutType);
        Assert.Equal(expected.OverallPar, actual.OverallPar);
        Assert.Equal(
            expected.HoleDtos.Select(hole => hole.Par), 
            actual.HoleDtos.Select(hole => hole.Par));
        Assert.Equal(
            expected.HoleDtos.Select(hole => hole.Yards), 
            actual.HoleDtos.Select(hole => hole.Yards));
        Assert.Equal(
            expected.HoleDtos.Select(hole => hole.HoleNumber),
            actual.HoleDtos.Select(hole => hole.HoleNumber));
    }

    [Fact]
    public void MapHoleLayoutListToDtoList_ReturnsHoleLayoutDtoList()
    {
        var expected = MockCourse.HoleLayoutDtos();
        var sut = new CourseMapper();
        var actual = sut.ConvertToHoleLayoutDtoList(MockCourse.HoleLayouts());

        Assert.Equal(expected.Count, actual.Count);
        Assert.Equal(
            expected.Select(holeLayout => holeLayout.Front9Yards),
            actual.Select(holeLayout => holeLayout.Front9Yards));
        Assert.Equal(
            expected.Select(holeLayout => holeLayout.Back9Yards),
            actual.Select(holeLayout => holeLayout.Back9Yards));
        Assert.Equal(
            expected.Select(holeLayout => holeLayout.CourseRating),
            actual.Select(holeLayout => holeLayout.CourseRating));
        Assert.Equal(
            expected.Select(holeLayout => holeLayout.SlopeRating),
            actual.Select(holeLayout => holeLayout.SlopeRating));
        Assert.Equal(
            expected.Select(holeLayout => holeLayout.LayoutType),
            actual.Select(holeLayout => holeLayout.LayoutType));
        Assert.Equal(
            expected.Select(holeLayout => holeLayout.OverallPar),
            actual.Select(holeLayout => holeLayout.OverallPar));
    }

    [Fact]
    public void MapHoleLayoutDtoToEntity_ReturnsHoleLayoutEntity()
    {
        var expected = MockCourse.HoleLayout();
        var sut = new CourseMapper();
        var actual = sut.ConvertToHoleLayoutEntity(MockCourse.HoleLayoutDto());

        Assert.Equal(expected.Front9Yards, actual.Front9Yards);
        Assert.Equal(expected.Back9Yards, actual.Back9Yards);
        Assert.Equal(expected.OverallPar, actual.OverallPar);
        Assert.Equal(expected.CourseRating, actual.CourseRating);
        Assert.Equal(expected.SlopeRating, actual.SlopeRating);
        Assert.Equal(expected.LayoutType, actual.LayoutType);
    }

    [Fact]
    public void MapHoleEntityToDto_ReturnsHoleDto()
    {
        var expected = MockCourse.HoleDto();
        var sut = new CourseMapper();
        var actual = sut.ConvertToHoleDto(MockCourse.Hole());

        Assert.Equal(expected.Par, actual.Par);
        Assert.Equal(expected.Yards, actual.Yards);
        Assert.Equal(expected.HoleNumber, actual.HoleNumber);
    }

    [Fact]
    public void MapHoleEntityListToDto_ReturnsHoleDtoList()
    {
        var expected = MockCourse.HoleDtos();
        var sut = new CourseMapper();
        var actual = sut.ConvertToHoleDtoList(MockCourse.Holes());

        Assert.Equal(expected.Count, actual.Count);
        Assert.Equal(
            expected.Select(hole => hole.Par), 
            actual.Select(hole => hole.Par));
        Assert.Equal(
            expected.Select(hole => hole.Yards), 
            actual.Select(hole => hole.Yards));
        Assert.Equal(
            expected.Select(hole => hole.HoleNumber), 
            actual.Select(hole => hole.HoleNumber));
    }

    [Fact]
    public void MapHoleDtoToEntity_ReturnsHoleEntity()
    {
        var expected = MockCourse.Hole();
        var sut = new CourseMapper();
        var actual = sut.ConvertToHoleEntity(MockCourse.HoleDto());

        Assert.Equal(expected.Par, actual.Par);
        Assert.Equal(expected.Yards, actual.Yards);
        Assert.Equal(expected.HoleNumber, actual.HoleNumber);
    }

    [Fact]
    public void MapHoleDtoListToEntityList_ReturnsHoleEntityList()
    {
        var expected = MockCourse.Holes();
        var sut = new CourseMapper();
        var actual = sut.ConvertToHoleEntityList(MockCourse.HoleDtos());

        Assert.Equal(expected.Count, actual.Count);
        Assert.Equal(
            expected.Select(hole => hole.Par), 
            actual.Select(hole => hole.Par));
        Assert.Equal(
            expected.Select(hole => hole.Yards), 
            actual.Select(hole => hole.Yards));
        Assert.Equal(
            expected.Select(hole => hole.HoleNumber), 
            actual.Select(hole => hole.HoleNumber));
    }

    [Fact]
    public void MapHoleLayoutDtoListToEntityList_ReturnsHoleLayoutEntityList()
    {
        var expected = MockCourse.HoleLayouts();
        var sut = new CourseMapper();
        var actual = sut.ConvertToHoleLayoutEntityList(MockCourse.HoleLayoutDtos());

        Assert.Equal(expected.Count, actual.Count);
        Assert.Equal(
            expected.Select(holeLayout => holeLayout.Front9Yards),
            actual.Select(holeLayout => holeLayout.Front9Yards));
        Assert.Equal(
            expected.Select(holeLayout => holeLayout.Back9Yards),
            actual.Select(holeLayout => holeLayout.Back9Yards));
        Assert.Equal(
            expected.Select(holeLayout => holeLayout.CourseRating),
            actual.Select(holeLayout => holeLayout.CourseRating));
        Assert.Equal(
            expected.Select(holeLayout => holeLayout.SlopeRating),
            actual.Select(holeLayout => holeLayout.SlopeRating));
        Assert.Equal(
            expected.Select(holeLayout => holeLayout.OverallPar),
            actual.Select(holeLayout => holeLayout.OverallPar));
    }
}