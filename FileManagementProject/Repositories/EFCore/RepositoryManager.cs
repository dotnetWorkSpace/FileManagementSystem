using FileManagementProject.Repositories.Contracts;

namespace FileManagementProject.Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_context));
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_context));
        }

        public IEmployeeRepository Employee=> _employeeRepository.Value;

        public IDepartmentRepository Department => _departmentRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
