namespace GolfMaxWebApi.Models.Entities;

public class HoleLayout
{
    public int Id { get; set; }
    public long Front9Yards { get; set; }
    public long Back9Yards { get; set; }
    public int OverallPar { get; set; }
    public double CourseRating { get; set; }
    public double SlopeRating { get; set; }
    public LayoutType LayoutType { get; set; }
    public List<Hole> Holes { get; set; } = null!;
    public int CourseId { get; set; }
}