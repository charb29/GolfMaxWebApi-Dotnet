using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course?> GetByCourseId(int id);
        Task<Course?> GetByCourseName(string courseName);
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(Course course, int id);
        Task DeleteById(int id);
    }
}