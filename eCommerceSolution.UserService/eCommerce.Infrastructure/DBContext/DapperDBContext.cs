
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DBContext
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public DapperDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            
            
            string? connectionString = _configuration.GetConnectionString("PostgresConnection");


            //create new connection
            _connection = new NpgsqlConnection(connectionString);
        }


        public IDbConnection DbConnection => _connection;


    }
}
