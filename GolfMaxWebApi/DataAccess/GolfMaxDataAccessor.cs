using System.Data;
using MySql.Data.MySqlClient;

namespace GolfMaxWebApi.DataAccess
{
    public class GolfMaxDataAccessor
    {
        private readonly string _connectionString;

        public GolfMaxDataAccessor(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("MySqlConnection");
        }

        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
    }
}
