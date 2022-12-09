using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Services.Interfaces;

public interface ICourseService
{
    Task<List<Course>> GetAllAsync();
    Task<Course?> GetByCourseIdAsync(int id);
    Task<Course?> GetByCourseNameAsync(string courseName);
    Task<Course> CreateCourseAsync(Course course);
    Task<bool> IsCourseAlreadyCreatedAsync(Course course);
    Task DeleteByIdAsync(int id);
}