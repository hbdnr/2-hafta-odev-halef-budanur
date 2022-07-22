using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;

namespace EduFlow_Odev2.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly string databaseType;
        public DapperDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            databaseType = configuration.GetConnectionString("DbType");
            connectionString = GetConnectionString();
        }
        private string GetConnectionString()
        {
            switch (databaseType)
            {
                case "SQL":
                    return this.configuration.GetConnectionString("DefaultConnection");
                case "PostgreSQL":
                    return this.configuration.GetConnectionString("PostgreSqlConnection");
                default:
                    return this.configuration.GetConnectionString("DefaultConnection");
            }
        }
        public IDbConnection CreateConnection()
        {
            switch (databaseType)
            {
                case "SQL":
                    return new SqlConnection(connectionString);
                case "PostgreSQL":
                    return new NpgsqlConnection(connectionString);
                default:
                    return new SqlConnection(connectionString);
            }
        }
    }
}
