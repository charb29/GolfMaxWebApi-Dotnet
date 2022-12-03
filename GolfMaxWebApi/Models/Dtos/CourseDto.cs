namespace GolfMaxWebApi.Models.Dtos;

public class CourseDto
{
    public string CourseName { get; set; } = null!;
    public List<HoleLayoutDto> HoleLayouts { get; set; } = null!;
}