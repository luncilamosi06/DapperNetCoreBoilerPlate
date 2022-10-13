using Dapper;
using RenzTest.Infrastructure;
using System.Data.SqlClient;

namespace RenzTest.Repository._Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration configuration;
        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Employee entity)
        {
            entity.InsertedDate = DateTime.Now;
            var sql = "Insert into vt_employee (Id,name,description) VALUES (@Id,@Name,@Description)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM vt_employee WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }
        public async Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            var sql = "SELECT * FROM vt_employee";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Employee>(sql);
                return result.ToList();
            }
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM vt_employee WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Employee>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<int> UpdateAsync(Employee entity)
        {
            var sql = "UPDATE vt_employee SET name = @Name, description = @Description  WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
