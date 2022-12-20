using System.Data;
using Dapper;
using GolfMaxWebApi.DataAccess;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;

namespace GolfMaxWebApi.Repositories.Implementations;

public class CourseRepository : ICourseRepository
{
    private readonly GolfMaxDataAccessor _dataAccessor;
    private readonly IHoleLayoutRepository _holeLayoutRepository;
    private readonly IHoleRepository _holeRepository;

    public CourseRepository(GolfMaxDataAccessor dataAccessor, 
                            IHoleLayoutRepository holeLayoutRepository,
                            IHoleRepository holeRepository)
    {
        _dataAccessor = dataAccessor ?? throw new ArgumentNullException(nameof(dataAccessor));
        _holeLayoutRepository = holeLayoutRepository;
        _holeRepository = holeRepository;
    }

    public async Task<IEnumerable<Course>> FindAllAsync()
    { 
        using var connection = _dataAccessor.CreateConnection();
        
        var courses = await connection.QueryAsync<Course>("GetAllCourses",
            commandType: CommandType.StoredProcedure);

        await AddCourseAttributesAsync(courses);
        return courses;
    }

    public async Task<Course?> FindByCourseIdAsync(int id)
    {
        using var connection = _dataAccessor.CreateConnection();
        
        var course = await connection.QueryFirstOrDefaultAsync<Course>("GetCourseById", 
            new { Id = id }, commandType: CommandType.StoredProcedure);
        var holeLayouts = await _holeLayoutRepository.FindByCourseIdAsync(course.Id);
        
        course.HoleLayouts = holeLayouts.ToList();
        return course;
    }

    public async Task<Course?> FindByCourseNameAsync(string courseName)
    {
        using var connection = _dataAccessor.CreateConnection();
        
        var course = await connection.QuerySingleOrDefaultAsync<Course>("GetCourseByCourseName",
            new { CourseName = courseName }, commandType: CommandType.StoredProcedure);
        var holeLayouts = await _holeLayoutRepository.FindByCourseIdAsync(course.Id);

        course.HoleLayouts = holeLayouts.ToList();
        return course;
    }

    public async Task<Course> SaveAsync(Course course)
    {
        using var connection = _dataAccessor.CreateConnection();

        var insertedCourseId = await connection.QuerySingleAsync<int>("InsertCourse", 
            new { course.CourseName }, commandType: CommandType.StoredProcedure);
        
        await _holeLayoutRepository.SaveAsync(course.HoleLayouts, insertedCourseId);

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
            new { Id = id }, commandType: CommandType.StoredProcedure);
    }

    public async Task<Course?> FindExistingCourseAsync(Course course)
    {
        using var connection = _dataAccessor.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("CourseName", course.CourseName);
        parameters.Add("Id", course.Id);
        
        var existingCourse = await connection.QuerySingleOrDefaultAsync<Course>("FindExistingCourse",
            parameters, commandType: CommandType.StoredProcedure);

        return existingCourse;
    }
    
    private async Task AddCourseAttributesAsync(IEnumerable<Course> courses)
    {
        foreach (var course in courses)
        {
            var holeLayouts = await _holeLayoutRepository.FindByCourseIdAsync(course.Id);
            foreach (var holeLayout in holeLayouts)
            {
                var holes = await _holeRepository.FindByHoleLayoutIdAsync(holeLayout.Id);
                holeLayout.Holes = holes.ToList();
            }
            
            course.HoleLayouts = holeLayouts.ToList();
        }
    }
}