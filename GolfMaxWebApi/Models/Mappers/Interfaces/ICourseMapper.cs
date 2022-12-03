using GolfMaxWebApi.Models.Dtos;
using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Models.Mappers.Interfaces;

public interface ICourseMapper
{
    CourseDto ConvertToCourseDto(Course course);
    List<CourseDto> ConvertToCourseDtoList(List<Course> courses);
    Course ConvertToCourseEntity(CourseDto courseDto);
        
    HoleLayoutDto ConvertToHoleLayoutDto(HoleLayout holeLayout);
    List<HoleLayoutDto> ConvertToHoleLayoutDtoList(List<HoleLayout> holeLayouts);
    HoleLayout ConvertToHoleLayoutEntity(HoleLayoutDto holeLayoutDto);
    List<HoleLayout> ConvertToHoleLayoutEntityList(List<HoleLayoutDto> holeLayoutDtos);

    HoleDto ConvertToHoleDto(Hole hole);
    List<HoleDto> ConvertToHoleDtoList(List<Hole> holes);
    Hole ConvertToHoleEntity(HoleDto holeDto);
    List<Hole> ConvertToHoleEntityList(List<HoleDto> holeDtos);
}