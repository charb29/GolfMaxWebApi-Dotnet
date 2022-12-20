namespace GolfMaxWebApi.Models.Entities;

public class Score
{
    public int Id { get; set; }
    public int TotalScore { get; set; }
    public int Front9Score { get; set; }
    public int Back9Score { get; set; }
    public int CourseId { get; set; }
    public int UserId { get; set; }
    public Course Course { get; set; } = null!;
}