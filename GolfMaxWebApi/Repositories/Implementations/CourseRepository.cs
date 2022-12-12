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
        
        var course = await connection.QueryFirstOrDefaultAsync<Course>("GetCourseById", 
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

        var insertedCourseId = await connection.QuerySingleAsync<int>("InsertCourse", 
            new { course.CourseName },
            commandType: CommandType.StoredProcedure);
        
        await SaveHoleLayoutsAsync(course.HoleLayouts, insertedCourseId);

        return new Course
        {
            Id = insertedCourseId,
            CourseName = course.CourseName,
            HoleLayouts = course.HoleLayouts
        };
    }

    public Task UpdateAsync(Course course)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteByIdAsync(int id)
    {
        using var connection = _dataAccessor.CreateConnection();
        
        await connection.ExecuteAsync("DeleteCourse", 
            new { Id = id }, 
            commandType: CommandType.StoredProcedure);
    }

    public async Task<Course?> FindExistingCourseAsync(Course course)
    {
        using var connection = _dataAccessor.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("CourseName", course.CourseName);
        parameters.Add("Id", course.Id);
        
        var existingCourse = await connection.QuerySingleOrDefaultAsync<Course>("FindExistingCourse",
            parameters,
            commandType: CommandType.StoredProcedure);

        return existingCourse;
    }
    
    private async Task SaveHoleLayoutsAsync(IEnumerable<HoleLayout> holeLayouts, int insertedCourseId)
    {
        var connection = _dataAccessor.CreateConnection();
        
        foreach (var holeLayout in holeLayouts)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Front9Yards", holeLayout.Front9Yards);
            parameters.Add("Back9Yards", holeLayout.Back9Yards);
            parameters.Add("OverallPar", holeLayout.OverallPar);
            parameters.Add("CourseRating", holeLayout.CourseRating);
            parameters.Add("SlopeRating", holeLayout.SlopeRating);
            parameters.Add("LayoutType", holeLayout.LayoutType);
            parameters.Add("CourseId", insertedCourseId);

            var insertedHoleLayoutId = await connection.QuerySingleAsync<int>("InsertHoleLayout", 
                parameters,
                commandType: CommandType.StoredProcedure);
            
            await SaveHolesAsync(holeLayout.Holes, insertedHoleLayoutId, insertedCourseId);
        }
    }

    private async Task SaveHolesAsync(IEnumerable<Hole> holes, int insertedHoleLayoutId, int insertedCourseId)
    {
        var connection = _dataAccessor.CreateConnection();
        
        foreach (var hole in holes)
        {
            var parameters = new DynamicParameters();
            parameters.Add("HoleNumber", hole.HoleNumber);
            parameters.Add("Yards", hole.Yards);
            parameters.Add("Par", hole.Par);
            parameters.Add("CourseId", insertedCourseId);
            parameters.Add("HoleLayoutId", insertedHoleLayoutId);

            await connection.QueryAsync<int>("InsertHole", 
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}