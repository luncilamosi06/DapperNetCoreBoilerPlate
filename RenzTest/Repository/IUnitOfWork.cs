namespace RenzTest.Repository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository employeeRepository { get; set; }
        IProjectRepository projectRepository { get; set; }
    }
}
