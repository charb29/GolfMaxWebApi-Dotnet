using GolfMaxWebApi.Models.Entities;

namespace GolfMaxWebApi.Repositories.Interfaces
{
    public interface IHoleRepository
    {
        Task<Hole> Save(Hole hole);
        Task<IEnumerable<Hole>> FindByHoleLayoutId(int id);
    }
}