using Dapper;
using System.Data;
using MySql.Data.MySqlClient;

namespace GolfMaxWebApi.DataAccess
{
    public partial class GolfMaxDataAccessor
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public GolfMaxDataAccessor(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("MySqlConnection");
        }

        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
    }
}
