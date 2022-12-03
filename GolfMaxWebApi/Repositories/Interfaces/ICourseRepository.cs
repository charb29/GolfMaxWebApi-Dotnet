using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Repositories.Interfaces;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> FindAllAsync();
    Task<Course?> FindByCourseIdAsync(int id);
    Task<Course?> FindByCourseNameAsync(string courseName);
    Task<Course> SaveAsync(Course course);
    Task UpdateAsync(Course course, int id);
    Task DeleteByIdAsync(int id);
}