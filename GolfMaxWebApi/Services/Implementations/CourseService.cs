using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Interfaces;

namespace GolfMaxWebApi.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository ?? 
                                throw new ArgumentNullException(nameof(courseRepository));
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var courses = await _courseRepository.FindAll();
            return courses.ToList();
        }

        public async Task<Course?> GetByCourseId(int id)
        {
            var course = await _courseRepository.FindByCourseId(id);
            return course;
        }

        public async Task<Course?> GetByCourseName(string courseName)
        {
            var course = await _courseRepository.FindByCourseName(courseName);
            return course;
        }
        public Task<Course> CreateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            await _courseRepository.DeleteById(id);
        }

        public Task<Course> UpdateCourse(Course course, int id)
        {
            throw new NotImplementedException();
        }
    }
}