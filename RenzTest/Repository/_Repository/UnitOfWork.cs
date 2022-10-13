namespace RenzTest.Repository._Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IEmployeeRepository _employeeRepository, IProjectRepository _projectRepository)
        {
            employeeRepository = _employeeRepository;
            projectRepository = _projectRepository;
        }
        public IEmployeeRepository employeeRepository { get; set; }
        public IProjectRepository projectRepository { get; set; }
    }  
}
