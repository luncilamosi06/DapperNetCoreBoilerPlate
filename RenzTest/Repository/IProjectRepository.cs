using RenzTest.Infrastructure;

namespace RenzTest.Repository
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<int> AddFormDataAsync(FormData formData);
    }
}
