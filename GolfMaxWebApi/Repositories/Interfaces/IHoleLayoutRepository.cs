using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Repositories.Interfaces;

public interface IHoleLayoutRepository
{
    Task<IEnumerable<HoleLayout>> FindByCourseIdAsync(int id);
    Task SaveAsync(IEnumerable<HoleLayout> holeLayouts, int insertedCourseId);
}