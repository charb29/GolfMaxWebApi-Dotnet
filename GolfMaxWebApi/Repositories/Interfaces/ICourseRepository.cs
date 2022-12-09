using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Repositories.Interfaces;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> FindAllAsync();
    Task<Course?> FindByCourseIdAsync(int id);
    Task<Course?> FindByCourseNameAsync(string courseName);
    Task<Course> SaveAsync(Course course);
    Task DeleteByIdAsync(int id);
    Task<Course?> FindExistingCourseAsync(Course course);
}