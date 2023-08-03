using AutoMapper;
using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Services.Contracts;

namespace FileManagementProject.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IDepartmentService> _departmentService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper) 
        {
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeManager(repositoryManager, logger, mapper));
            _departmentService = new Lazy<IDepartmentService>(() => new DepartmentManager(repositoryManager, logger, mapper));
        }
        public IEmployeeService EmployeeService => _employeeService.Value;

        public IDepartmentService DepartmentService => _departmentService.Value;
    }

}
