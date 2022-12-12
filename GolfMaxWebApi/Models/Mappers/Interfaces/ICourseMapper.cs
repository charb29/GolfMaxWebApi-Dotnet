using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Models.Mappers.Interfaces;

public interface ICourseMapper
{
    CourseDto ConvertToCourseDto(Course course);
    ICollection<CourseDto> ConvertToCourseDtoList(IEnumerable<Course> courses);
    Course ConvertToCourseEntity(CourseDto courseDto);
        
    HoleLayoutDto ConvertToHoleLayoutDto(HoleLayout holeLayout);
    ICollection<HoleLayoutDto> ConvertToHoleLayoutDtoList(IEnumerable<HoleLayout> holeLayouts);
    HoleLayout ConvertToHoleLayoutEntity(HoleLayoutDto holeLayoutDto);
    ICollection<HoleLayout> ConvertToHoleLayoutEntityList(IEnumerable<HoleLayoutDto> holeLayoutDtos);

    HoleDto ConvertToHoleDto(Hole hole);
    ICollection<HoleDto> ConvertToHoleDtoList(IEnumerable<Hole> holes);
    Hole ConvertToHoleEntity(HoleDto holeDto);
    ICollection<Hole> ConvertToHoleEntityList(IEnumerable<HoleDto> holeDtos);
}