using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Models.Dtos;

public class HoleLayoutDto
{
    public long Front9Yards { get; set; }
    public long Back9Yards { get; set; }
    public int OverallPar { get; set; }
    public double CourseRating { get; set; }
    public double SlopeRating { get; set; }
    public LayoutType LayoutType { get; set; }
    public List<HoleDto> HoleDtos { get; set; } = null!;
}