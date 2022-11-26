namespace GolfMaxWebApi.Models.Entities
{
    public class Hole
    {
        public int Id { get; set; }
        public int HoleNumber { get; set; }
        public int Yards { get; set; }
        public int Par { get; set; }

        public HoleLayout HoleLayout { get; set; }
        public Course Course { get; set; }
    }
}