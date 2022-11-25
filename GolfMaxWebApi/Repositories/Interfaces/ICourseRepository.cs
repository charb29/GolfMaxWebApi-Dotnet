using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> FindAll();
        Task<Course?> FindByCourseId(int id);
        Task<Course?> FindByCourseName(string courseName);
        Task<Course> Save(Course course);
        Task Update(Course course, int id);
        Task DeleteById(int id);
    }
}