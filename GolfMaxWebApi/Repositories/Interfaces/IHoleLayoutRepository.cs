using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Repositories.Interfaces;

public interface IHoleLayoutRepository
{
    Task<IEnumerable<HoleLayout>> FindByCourseId(int id);
    Task<IEnumerable<HoleLayout>> Save(IEnumerable<HoleLayout> holeLayouts);
}