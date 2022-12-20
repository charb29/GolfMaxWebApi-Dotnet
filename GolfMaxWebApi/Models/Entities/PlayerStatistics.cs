namespace GolfMaxWebApi.Models.Entities;

public class PlayerStatistics
{
    public int Id { get; set; }
    public int RoundsPlayed { get; set; }
    public int UserId { get; set; }
    public double AverageScore { get; set; }
    public double HandicapIndex { get; set; }
}