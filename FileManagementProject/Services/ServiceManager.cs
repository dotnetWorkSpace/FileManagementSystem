using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Services.Contracts;

namespace FileManagementProject.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IDepartmentService> _departmentService;
        public ServiceManager(IRepositoryManager repositoryManager) 
        {
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeManager(repositoryManager));
            _departmentService = new Lazy<IDepartmentService>(() => new DepartmentManager(repositoryManager));
        }
        public IEmployeeService EmployeeService => _employeeService.Value;

        public IDepartmentService DepartmentService => _departmentService.Value;
    }

}
