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
            var courseQuery = "INSERT INTO courses (course_name)"
                + " VALUES (@CourseName)";
            var holeLayoutQuery = "INSERT INTO hole_layouts ("
                + " front_9_yards, back_9_yards, overall_par,"
                + " course_rating, slope_rating, layout_type"
                + " course_id)"
                + " VALUES (@Front9Yards, @Back9Yards, @OverallPar"
                + " @CourseRating, @SlopeRating, @LaoutType)";
            var holeQuery = "INSERT INTO holes ("
                + " par, yards, hole_number)"
                + " VALUES (@Par, @Yards, @HoleNumber)";

            var parameters = new DynamicParameters();
            parameters.Add("CourseName", course.CourseName, DbType.String);

            using var connection = _dataAccessor.CreateConnection();
            var courseId = await connection.ExecuteAsync(courseQuery, parameters);
            var holeLayoutId = await connection.ExecuteAsync(holeLayoutQuery, course.HoleLayouts);
            var holeId = await connection.ExecuteAsync(holeQuery, course.HoleLayouts.SelectMany(h => h.Holes));

            return new Course
            {
                Id = courseId,
                CourseName = course.CourseName,
                HoleLayouts = course.HoleLayouts
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