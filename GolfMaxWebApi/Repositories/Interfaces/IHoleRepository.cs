using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Repositories.Interfaces;

public interface  IHoleRepository
{
    Task SaveAsync(IEnumerable<Hole> holes, int insertedHoleLayoutId, int insertedCourseId);
    Task<IEnumerable<Hole>> FindByCourseAndHoleLayoutIdAsync(int holeLayoutId);
}