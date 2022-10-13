using Dapper;
using RenzTest.Infrastructure;
using System.Data.SqlClient;

namespace RenzTest.Repository._Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IConfiguration configuration;
        public ProjectRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Project entity)
        {
            entity.InsertedDate = DateTime.Now;
            var sql = "Insert into vt_project (Id,name,description) VALUES (@Id,@Name,@Description)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> AddFormDataAsync(FormData formData)
        {
            var sql = "dbo.insertFormData";

            if(formData.dataEmployee != null)
            {
                foreach(var dataEmployee in formData.dataEmployee)
                {
                    var parametersEmployee = new
                    {
                        EmployeeDetailsID = Guid.NewGuid(),
                        EmployeeID = dataEmployee.employeeID,
                        EstimatedHours = dataEmployee.estimatedHours,
                        ActualHours = dataEmployee.actualHours,
                        ProjectDetailsID = dataEmployee.projectDetailsID,
                        CreatedBy = dataEmployee.createdBy,
                        ExecutionProcess = true
                    };
                    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.QueryAsync(sql, parametersEmployee, commandType: System.Data.CommandType.StoredProcedure);
                    }
                }
            } 


            var parameters = new { ProjectDetailsID = new Guid(), ProjectID = formData.projectDetails.projectID,
                TaskDescription = formData.projectDetails.TaskDescription,
                TotalEstimate = formData.projectDetails.TotalEstimate,
                TaskTitle = formData.projectDetails.TaskTitle,
                InsertedBy = formData.projectDetails.InsertedBy,
                ExecutionProcess = false
            };
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return formData.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM vt_project WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }
        public async Task<IReadOnlyList<Project>> GetAllAsync()
        {
            var sql = "SELECT * FROM vt_project";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Project>(sql);
                return result.ToList();
            }
        }
        public async Task<Project> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM vt_project WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Project>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<int> UpdateAsync(Project entity)
        {
            var sql = "UPDATE vt_project SET name = @Name, description = @Description WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
