using Dapper;
using System.Data;
using GolfMaxWebApi.DataAccess;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;

namespace GolfMaxWebApi.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly GolfMaxDataAccessor _dataAccessor;

        public CourseRepository(GolfMaxDataAccessor dataAccessor)
        {
            if (dataAccessor is null)
                throw new ArgumentNullException(nameof(dataAccessor));

            _dataAccessor = dataAccessor;
        }

        public async Task<IEnumerable<Course>> FindAll()
        {
            const string query = "SELECT * FROM courses, hole_layouts, holes";

            using var connection = _dataAccessor.CreateConnection();
            var courses = await connection.QueryAsync<Course>(query);

            return courses;
        }

        public async Task<Course?> FindByCourseId(int id)
        {
            var query = "SELECT course.*, holeLayout.*, h.* "
                    + " FROM courses course, hole_layouts holeLayout, holes h "
                    + " WHERE course.id = @id";

            using var connection = _dataAccessor.CreateConnection();
            var course = await connection.QueryAsync<Course>(query, new { id });

            return course.SingleOrDefault();
        }

        public async Task<Course?> FindByCourseName(string courseName)
        {
            var query = "SELECT course.*, holeLayout.*, h.* "
                    + " FROM courses course, hole_layouts holeLayout, holes h "
                    + " WHERE course.course_name = @courseName";

            using var connection = _dataAccessor.CreateConnection();
            var course = await connection.QueryAsync<Course>(query, new { courseName });

            return course.SingleOrDefault();
        }

        public async Task<Course> Save(Course course)
        {
            var courseQuery = "INSERT INTO courses (course_name) VALUES (@CourseName)";

            var parameters = new DynamicParameters();
            parameters.Add("CourseName", course.CourseName, DbType.String);

            using var connection = _dataAccessor.CreateConnection();
            var courseId = await connection.ExecuteAsync(courseQuery, parameters);

            var holeLayouts = new List<HoleLayout>();
            var holes = new List<Hole>();

            foreach (HoleLayout holeLayout in course.HoleLayouts)
            {
                var holeLayoutQuery = "INSERT INTO hole_layouts ("
                    + " overall_par, course_rating,"
                    + " slope_rating, front_9_yards,"
                    + " back_9_yards, layout_type, course_id)"
                    + " VALUES (@OverallPar, @CourseRating,"
                    + " @SlopeRating, @Front9Yards,"
                    + " @Back9Yards, @LayoutType, @Course)";

                parameters.Add("OverallPar", holeLayout.OverallPar, DbType.Int32);
                parameters.Add("CourseRating", holeLayout.CourseRating, DbType.Decimal);
                parameters.Add("SlopeRating", holeLayout.SlopeRating, DbType.Decimal);
                parameters.Add("Front9Yards", holeLayout.Front9Yards, DbType.Decimal);
                parameters.Add("Back9Yards", holeLayout.Back9Yards, DbType.Decimal);
                parameters.Add("LayoutType", holeLayout.LayoutType, DbType.String);
                parameters.Add("Course", courseId, DbType.Int16);

                var holeLayoutId = await connection.ExecuteAsync(holeLayoutQuery, parameters);

                foreach (Hole hole in holeLayout.Holes)
                {
                    var holeQuery = "INSERT INTO holes ("
                        + " hole_number, yards, par,"
                        + " hole_layout_id, course_id"
                        + "VALUES (@HoleNumber, @Yards"
                        + " @Par, @HoleLayout, @Course)";

                    parameters.Add("HoleNumber", hole.HoleNumber, DbType.Int16);
                    parameters.Add("Yards", hole.Yards, DbType.Int16);
                    parameters.Add("Par", hole.Par, DbType.Int16);
                    parameters.Add("HoleLayout", holeLayoutId, DbType.Int16);
                    parameters.Add("Course", courseId, DbType.Int16);

                    var holeId = await connection.ExecuteAsync(holeQuery, parameters);

                    holes.Add(new Hole
                    {
                        Id = holeId,
                        Yards = hole.Par,
                        HoleLayout = holeLayout,
                        Course = hole.Course
                    });
                }

                holeLayouts.Add(new HoleLayout
                {
                    Id = holeLayoutId,
                    CourseRating = holeLayout.CourseRating,
                    SlopeRating = holeLayout.SlopeRating,
                    Front9Yards = holeLayout.Front9Yards,
                    Back9Yards = holeLayout.Back9Yards,
                    LayoutType = holeLayout.LayoutType,
                    Course = holeLayout.Course,
                    Holes = holes
                });
            }

            return new Course
            {
                Id = courseId,
                CourseName = course.CourseName,
                HoleLayouts = holeLayouts
            };
        }

        public Task Update(Course course, int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            var query = "DELETE FROM courses c WHERE c.id = @id";

            using var connection = _dataAccessor.CreateConnection();
            await connection.ExecuteAsync(query, new { id });
        }
    }
}