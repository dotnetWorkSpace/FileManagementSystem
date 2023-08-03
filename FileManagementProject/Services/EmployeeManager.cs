using FileManagementProject.Entities.Exceptions;
using FileManagementProject.Entities.Models;
using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Services.Contracts;

namespace FileManagementProject.Services
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;

        public EmployeeManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public Employee CreateOneEmployee(Employee employee)
        {

            _manager.Employee.CreateOneEmployee(employee);
            _manager.Save();
            return employee;
        }

        public void DeleteOneEmployee(int id, bool trackChanges)
        {
            // check entity
            var entity = _manager.Employee.GetOneEmployeeById(id, trackChanges);
            if (entity is null)
                throw new EmployeeNotFoundException(id);

            _manager.Employee.DeleteOneEmployee(entity);
            _manager.Save();
        }

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges)
        {
            return _manager.Employee.GetAllEmployees(trackChanges);

        }

        public Employee GetOneEmployeeById(int id, bool trackChanges)
        {
            var employee =  _manager.Employee.GetOneEmployeeById(id, trackChanges);
            if(employee is null)
                throw new EmployeeNotFoundException(id);
            return employee;
        }

        public Employee GetOneEmployeeWithDepartment(int id, bool trackChanges)
        {
            return _manager.Employee.GetOneEmployeeWithDepartment(id, trackChanges);
        }

        public void UpdateOneEmployee(int id, Employee employee, bool trackChanges)
        {
            //check entity
            var entity = _manager.Employee.GetOneEmployeeById(id, trackChanges);
            if (entity is null)
                throw new EmployeeNotFoundException(id);

            entity.EmployeeFirstName = employee.EmployeeFirstName;
            entity.EmployeeLastName = employee.EmployeeLastName;
            entity.DepartmentId = employee.DepartmentId;

            _manager.Employee.Update(entity);
            _manager.Save();


        }
    }
}
