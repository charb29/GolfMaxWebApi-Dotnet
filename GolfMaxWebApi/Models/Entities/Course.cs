namespace GolfMaxWebApi.Models.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public List<HoleLayout> HoleLayouts { get; set; }
    }
}