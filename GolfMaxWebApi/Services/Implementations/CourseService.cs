using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;
using GolfMaxWebApi.Services.Interfaces;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GolfMaxWebApi.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            if (courseRepository is null)
                throw new ArgumentNullException(nameof(courseRepository));

            _courseRepository = courseRepository;
        }

        public Task<IEnumerable<Course>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetByCourseId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetByCourseName(string courseName)
        {
            throw new NotImplementedException();
        }
        public Task<Course> CreateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> UpdateCourse(Course course, int id)
        {
            throw new NotImplementedException();
        }
    }
}