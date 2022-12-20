using System.Data;
using Dapper;
using GolfMaxWebApi.DataAccess;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;

namespace GolfMaxWebApi.Repositories.Implementations;

public class HoleRepository : IHoleRepository
{
    private readonly GolfMaxDataAccessor _dataAccessor;

    public HoleRepository(GolfMaxDataAccessor dataAccessor)
    {
        _dataAccessor = dataAccessor;
    }

    public async Task<IEnumerable<Hole>> FindByHoleLayoutIdAsync(int holeLayoutId)
    {
        using var connection = _dataAccessor.CreateConnection();

        var holes = await connection.QueryAsync<Hole>("GetHolesByHoleLayoutId",
            new { HoleLayoutId = holeLayoutId }, commandType: CommandType.StoredProcedure);
        
        return holes;
    }

    public async Task SaveAsync(IEnumerable<Hole> holes, int insertedHoleLayoutId, int insertedCourseId)
    {
        using var connection = _dataAccessor.CreateConnection();
        
        foreach (var hole in holes)
        {
            var parameters = new DynamicParameters();
            parameters.Add("HoleNumber", hole.HoleNumber);
            parameters.Add("Yards", hole.Yards);
            parameters.Add("Par", hole.Par);
            parameters.Add("CourseId", insertedCourseId);
            parameters.Add("HoleLayoutId", insertedHoleLayoutId);

            await connection.QueryAsync<int>("InsertHole", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}