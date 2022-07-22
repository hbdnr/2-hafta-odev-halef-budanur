using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EduFlow_Odev2.Data
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DapperDbContext dapperDbContext;

        public CountryRepository(DapperDbContext dapperDbContext) : base()
        {
            this.dapperDbContext = dapperDbContext;
        }

        public Task<IEnumerable<Country>> FindAsync(Expression<Func<Country, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> FindByNameAsync(string FirstName)
        {
            var sql = $"SELECT * FROM dbo.country WHERE Name like @CountryName";
            using (var connection = dapperDbContext.CreateConnection())
            {
                var result = connection.QueryAsync<Country>(sql, new { FirstName });
                return result;
            }
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            var sql = "SELECT * FROM dbo.country";
            using (var connection = dapperDbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<Country>(sql);
                return result;
            }
        }

        public async Task<Country> GetByIdAsync(int Id)
        {
            var query = "SELECT * FROM dbo.country WHERE CountryId = @CountryId";
            using (var connection = dapperDbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<Country>(query, new { Id });
                return result;
            }
        }

        public async Task InsertAsync(Country entity)
        {
            var query = "INSERT INTO dbo.country (CountryId, CountryName, Continent,Currency ) " +
                "VALUES (@CountryId, @CountryName, @Continent,@Currency)";

            //entity.CreatedAt = DateTime.UtcNow;

            var parameters = new DynamicParameters();
            parameters.Add("CountryId", entity.CountryId, DbType.Int32);
            parameters.Add("CountryName", entity.CountryName, DbType.String);
            parameters.Add("Continent", entity.Continent, DbType.String);
            parameters.Add("Currency", entity.Currency, DbType.String);

            using (var connection = dapperDbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void RemoveAsync(Country entity)
        {
            var query = "DELETE FROM dbo.country WHERE CountryId = @CountryId";
            using (var connection = dapperDbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, new { entity.CountryId });
            }
        }

        public Task<int> TotalRecordAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Country entity)
        {
            throw new NotImplementedException();
        }

      
    }
}
