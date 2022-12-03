using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Interfaces;

namespace GolfMaxWebApi.Services.Implementations;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
    }

    public async Task<List<Course>> GetAllAsync()
    {
        var courses = await _courseRepository.FindAllAsync();
        return courses.ToList();
    }

    public async Task<Course?> GetByCourseIdAsync(int id)
    {
        var course = await _courseRepository.FindByCourseIdAsync(id);
        return course;
    }

    public async Task<Course?> GetByCourseNameAsync(string courseName)
    {
        var course = await _courseRepository.FindByCourseNameAsync(courseName);
        return course;
    }

    public async Task<Course> CreateCourseAsync(Course course)
    {
        var createCourse = await _courseRepository.SaveAsync(course);
        return createCourse;
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _courseRepository.DeleteByIdAsync(id);
    }

    public Task<Course> UpdateCourseAsync(Course course, int id)
    {
        throw new NotImplementedException();
    }
}