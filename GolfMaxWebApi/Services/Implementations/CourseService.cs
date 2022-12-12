using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Interfaces;

namespace GolfMaxWebApi.Services.Implementations;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;

    public CourseService(ICourseRepository courseRepository)
    {
        _repository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        var courses = await _repository.FindAllAsync();
        return courses;
    }

    public async Task<Course?> GetByCourseIdAsync(int id)
    {
        var course = await _repository.FindByCourseIdAsync(id);
        return course;
    }

    public async Task<Course?> GetByCourseNameAsync(string courseName)
    {
        var course = await _repository.FindByCourseNameAsync(courseName);
        return course;
    }

    public async Task<Course> CreateCourseAsync(Course course)
    {
        var createdCourse = await _repository.SaveAsync(course);
        return createdCourse;
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
    }

    public async Task<bool> IsCourseAlreadyCreatedAsync(Course course)
    {
        var storedCourse = await _repository.FindExistingCourseAsync(course);
        return storedCourse == null;
    }
}