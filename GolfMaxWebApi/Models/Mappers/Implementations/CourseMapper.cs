using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Models.Mappers.Interfaces;

namespace GolfMaxWebApi.Models.Mappers.Implementations;

public class CourseMapper : ICourseMapper
{
    public CourseDto ConvertToCourseDto(Course course)
    {
        return new CourseDto
        {
            CourseName = course.CourseName,
            HoleLayouts = ConvertToHoleLayoutDtoList(course.HoleLayouts)
        };
    }

    public ICollection<CourseDto> ConvertToCourseDtoList(IEnumerable<Course> courses)
    {
        var courseDtos = courses.Select(ConvertToCourseDto);
        return courseDtos.ToList();
    }

    public Course ConvertToCourseEntity(CourseDto courseDto)
    {
        return new Course
        {
            CourseName = courseDto.CourseName,
            HoleLayouts = ConvertToHoleLayoutEntityList(courseDto.HoleLayouts)
        };
    }

    public HoleLayout ConvertToHoleLayoutEntity(HoleLayoutDto holeLayoutDto)
    {
        return new HoleLayout
        {
            Front9Yards = holeLayoutDto.Front9Yards,
            Back9Yards = holeLayoutDto.Back9Yards,
            CourseRating = holeLayoutDto.CourseRating,
            SlopeRating = holeLayoutDto.SlopeRating,
            OverallPar = holeLayoutDto.OverallPar,
            LayoutType = holeLayoutDto.LayoutType,
            Holes = ConvertToHoleEntityList(holeLayoutDto.HoleDtos)
        };
    }

    public HoleLayoutDto ConvertToHoleLayoutDto(HoleLayout holeLayout)
    {
        return new HoleLayoutDto
        {
            Front9Yards = holeLayout.Front9Yards,
            Back9Yards = holeLayout.Back9Yards,
            CourseRating = holeLayout.CourseRating,
            SlopeRating = holeLayout.SlopeRating,
            OverallPar = holeLayout.OverallPar,
            LayoutType = holeLayout.LayoutType,
            HoleDtos = ConvertToHoleDtoList(holeLayout.Holes)
        };
    }

    public ICollection<HoleLayout> ConvertToHoleLayoutEntityList(IEnumerable<HoleLayoutDto> holeLayoutDtos)
    {
        var holeLayouts = holeLayoutDtos.Select(ConvertToHoleLayoutEntity);
        return holeLayouts.ToList();
    }

    public ICollection<HoleLayoutDto> ConvertToHoleLayoutDtoList(IEnumerable<HoleLayout> holeLayouts)
    {
        var holeLayoutDtos = holeLayouts.Select(ConvertToHoleLayoutDto);
        return holeLayoutDtos.ToList();
    }

    public Hole ConvertToHoleEntity(HoleDto holeDto)
    {
        return new Hole
        {
            Par = holeDto.Par,
            Yards = holeDto.Yards,
            HoleNumber = holeDto.HoleNumber
        };
    }

    public HoleDto ConvertToHoleDto(Hole hole)
    {
        return new HoleDto
        {
            Par = hole.Par,
            Yards = hole.Yards,
            HoleNumber = hole.HoleNumber
        };
    }

    public ICollection<Hole> ConvertToHoleEntityList(IEnumerable<HoleDto> holeDtos)
    {
        var holes = holeDtos.Select(ConvertToHoleEntity);
        return holes.ToList();
    }

    public ICollection<HoleDto> ConvertToHoleDtoList(IEnumerable<Hole> holes)
    {
        var holeDtos = holes.Select(ConvertToHoleDto);
        return holeDtos.ToList();
    }
}