using System.Data;
using Dapper;
using GolfMaxWebApi.DataAccess;
using GolfMaxWebApi.Models.Entities;
using GolfMaxWebApi.Repositories.Interfaces;

namespace GolfMaxWebApi.Repositories.Implementations;

public class HoleLayoutRepository : IHoleLayoutRepository
{
    private readonly GolfMaxDataAccessor _dataAccessor;
    private readonly IHoleRepository _holeRepository;

    public HoleLayoutRepository(GolfMaxDataAccessor dataAccessor, IHoleRepository holeRepository)
    {
        _dataAccessor = dataAccessor;
        _holeRepository = holeRepository;
    }

    public async Task<IEnumerable<HoleLayout>> FindByCourseIdAsync(int courseId)
    {
        using var connection = _dataAccessor.CreateConnection();

        var holeLayouts = await connection.QueryAsync<HoleLayout>("GetHoleLayoutsByCourseId", 
            new { CourseId = courseId }, commandType: CommandType.StoredProcedure);

        if (holeLayouts is null) throw new NullReferenceException("Attempting to query non-existing data.");

        return holeLayouts;
    }

    public async Task SaveAsync(IEnumerable<HoleLayout> holeLayouts, int insertedCourseId)
    {
        using var connection = _dataAccessor.CreateConnection();
        
        foreach (var holeLayout in holeLayouts)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Front9Yards", holeLayout.Front9Yards);
            parameters.Add("Back9Yards", holeLayout.Back9Yards);
            parameters.Add("OverallPar", holeLayout.OverallPar);
            parameters.Add("CourseRating", holeLayout.CourseRating);
            parameters.Add("SlopeRating", holeLayout.SlopeRating);
            parameters.Add("LayoutType", holeLayout.LayoutType);
            parameters.Add("CourseId", insertedCourseId);

            var insertedHoleLayoutId = await connection.QuerySingleAsync<int>("InsertHoleLayout", 
                parameters, commandType: CommandType.StoredProcedure);

            await _holeRepository.SaveAsync(holeLayout.Holes, insertedHoleLayoutId, insertedCourseId);
        }
    }
}