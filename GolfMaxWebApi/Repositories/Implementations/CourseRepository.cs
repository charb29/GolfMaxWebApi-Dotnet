using System.Data;
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
        using var connection = _dataAccessor.CreateConnection();
        var courses = await connection.QueryAsync<Course>("GetAllCourses", 
            commandType: CommandType.StoredProcedure);

        return courses;
    }

    public async Task<Course?> FindByCourseIdAsync(int id)
    {
        using var connection = _dataAccessor.CreateConnection();
        var course = await connection.QuerySingleOrDefaultAsync<Course>("GetCourseById", 
            new { Id = id },
            commandType: CommandType.StoredProcedure);

        return course;
    }

    public async Task<Course?> FindByCourseNameAsync(string courseName)
    {
        using var connection = _dataAccessor.CreateConnection();
        var course = await connection.QuerySingleOrDefaultAsync<Course>("GetCourseByCourseName",
            new { CourseName = courseName },
            commandType: CommandType.StoredProcedure);

        return course;
    }

    public async Task<Course> SaveAsync(Course course)
    {
        using var connection = _dataAccessor.CreateConnection();
        var id = await connection.QuerySingleAsync<int>("InsertCourse", new { Course = course },
            commandType: CommandType.StoredProcedure);

        course.Id = id;
        return course;
    }

    public Task UpdateAsync(Course course, int id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteByIdAsync(int id)
    {
        using var connection = _dataAccessor.CreateConnection();
        await connection.ExecuteAsync("DeleteCourse", new { Id = id }, commandType: CommandType.StoredProcedure);
    }

    public async Task<Course?> FindExistingCourseAsync(Course course)
    {
        using var connection = _dataAccessor.CreateConnection();
        var existingCourse = await connection.QuerySingleOrDefaultAsync<Course>("FindExistingCourse", 
            new { Course = course },
            commandType: CommandType.StoredProcedure);

        return existingCourse;
    }
}