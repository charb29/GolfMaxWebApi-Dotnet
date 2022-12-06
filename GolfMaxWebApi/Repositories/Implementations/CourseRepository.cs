using Dapper;
using GolfMaxWebApi.DataAccess;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;

namespace GolfMaxWebApi.Repositories.Implementations;

public class CourseRepository : ICourseRepository
{
    private readonly GolfMaxDataAccessor _dataAccessor;

    public CourseRepository(GolfMaxDataAccessor dataAccessor)
    {
        _dataAccessor = dataAccessor ?? throw new ArgumentNullException(nameof(dataAccessor));
    }

    public async Task<IEnumerable<Course>> FindAllAsync()
    {
        const string query = "SELECT * FROM courses c " +
                             "INNER JOIN hole_layouts hl " +
                             "ON c.id = hl.course_id " +
                             "INNER JOIN holes h " +
                             "ON c.id = h.course_id";

        using var connection = _dataAccessor.CreateConnection();
        var courses = await connection.QueryAsync<Course>(query);

        return courses;
    }

    public async Task<Course?> FindByCourseIdAsync(int id)
    {
        const string query = "SELECT * FROM courses c" +
                             "INNER JOIN hole_layouts hl " +
                             "ON c.id = hl.course_id " +
                             "INNER JOIN holes h " +
                             "ON c.id = h.course_id " +
                             "WHERE c.id = @id";

        using var connection = _dataAccessor.CreateConnection();
        var course = await connection.QuerySingleOrDefaultAsync<Course>(query, new { id });

        return course;
    }

    public async Task<Course?> FindByCourseNameAsync(string courseName)
    {
        const string query = "SELECT * FROM courses c " +
                             "INNER JOIN hole_layouts hl " +
                             "ON c.id = hl.course_id " +
                             "INNER JOIN holes h " +
                             "ON c.id = h.course_id " +
                             "WHERE c.course_name = @courseName";

        using var connection = _dataAccessor.CreateConnection();
        var course = await connection.QuerySingleOrDefaultAsync<Course>(query, new { courseName });

        return course;
    }

    public Task<Course> SaveAsync(Course course)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Course course, int id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteByIdAsync(int id)
    {
        const string query = "DELETE FROM courses c " +
                             "INNER JOIN hole_layouts hl " +
                             "ON c.id = hl.course_id" +
                             "INNER JOIN holes h " +
                             "ON c.id = h.course_id" +
                             "WHERE c.id = @id";

        using var connection = _dataAccessor.CreateConnection();
        await connection.ExecuteAsync(query, new { id });
    }

    public async Task<Course?> FindExistingCourseAsync(Course course)
    {
        const string query = "SELECT * FROM courses c " +
                             "WHERE c.course_name = @CourseName " +
                             "OR c.id = @Id";

        using var connection = _dataAccessor.CreateConnection();
        var storedCourse = await connection.QuerySingleOrDefaultAsync<Course>(query, course);

        return storedCourse;
    }
}