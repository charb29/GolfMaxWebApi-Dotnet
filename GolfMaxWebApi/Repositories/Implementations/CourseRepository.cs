using Dapper;
using System.Data;
using GolfMaxWebApi.DataAccess;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;

namespace GolfMaxWebApi.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly GolfMaxDataAccessor _dataAccessor;

        public CourseRepository(GolfMaxDataAccessor dataAccessor)
        {
            if (dataAccessor is null)
                throw new ArgumentNullException(nameof(dataAccessor));

            _dataAccessor = dataAccessor;
        }

        public async Task<IEnumerable<Course>> FindAll()  c 
        {
            throw new NotImplementedException();
    }

    public async Task<Course?> FindByCourseId(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Course?> FindByCourseName(string courseName)
    {
        throw new NotImplementedException();
    }

    public async Task<Course> Save(Course course)
    {
        throw new NotImplementedException();
    }

    public Task Update(Course course, int id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}
}