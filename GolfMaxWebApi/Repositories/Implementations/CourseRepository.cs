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
            var query = "SELECT * FROM courses c"
                + " INNER JOIN hole_layouts hl ON c.id = hl.course_id"
                + " INNER JOIN holes h ON c.id = h.course_id";

            using var connection = _dataAccessor.CreateConnection();
            var courses = await connection.QueryAsync<Course>(query);

            return courses;
        }

        public async Task<Course?> FindByCourseId(int id)
        {
            var query = "SELECT * FROM courses c"
                + " INNER JOIN hole_layouts hl ON c.id = hl.course_id"
                + " INNER JOIN holes h ON c.id = h.course_id"
                + " WHERE c.id = @id";

            using var connection = _dataAccessor.CreateConnection();
            var course = await connection.QuerySingleOrDefaultAsync<Course>(query, new { id });

            return course;
        }

        public async Task<Course?> FindByCourseName(string courseName)
        {
            var query = "SELECT * FROM courses c"
               + " INNER JOIN hole_layouts hl ON c.id = hl.course_id"
               + " INNER JOIN holes h ON c.id = h.course_id"
               + " WHERE c.username = @username";

            using var connection = _dataAccessor.CreateConnection();
            var course = await connection.QuerySingleOrDefaultAsync<Course>(query, new { courseName });

            return course;
        }

        public async Task<Course> Save(Course course)
        {
            var courseQuery = "INSERT INTO courses (course_name)"
                + " VALUES (@CourseName);"
                + " SELECT LAST_INSERT_ID();";

            using var connection = _dataAccessor.CreateConnection();

            var courseId = await connection.QuerySingleAsync<int>(courseQuery, course);
            course.Id = courseId;

            var holeLayoutQuery = "INSERT INTO hole_layouts"
                + " (front_9_yards, back_9_yards, overall_par,"
                + " course_rating, slope_rating, layout_type, course_id)"
                + " VALUES (@Front9Yards, @Back9Yards, @OverallPar,"
                + " @CourseRating, @SlopeRating, @LayoutType, @CourseId);"
                + " SELECT LAST_INSERT_ID();";

            var holeLayoutId = await connection.QuerySingleAsync<int>(
                holeLayoutQuery, course.HoleLayouts);
            course.HoleLayouts.Select(holeLayouts => holeLayouts.Id = holeLayoutId);

            var holeQuery = "INSERT INTO holes"
                + " (hole_number, yards, par, course_id, hole_layout_id)"
                + " VALUES (@HoleNumber, @Yards, @Par, @CourseId, @HoleLayoutId);"
                + " SELECT_LAST_INSERT_ID();";

            var holeId = await connection.QuerySingleAsync<int>(
                holeQuery, course.HoleLayouts.SelectMany(holeLayout => holeLayout.Holes));
            course.HoleLayouts.Select(hole => hole.Id = holeId);

            return course;
        }

        public Task Update(Course course, int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            var query = "DELETE FROM courses c"
               + " INNER JOIN hole_layouts hl ON c.id = hl.course_id"
               + " INNER JOIN holes h ON c.id = h.course_id"
               + " WHERE c.id = @id";

            using var connection = _dataAccessor.CreateConnection();
            await connection.ExecuteAsync(query, new { id });
        }
    }
}