using AutoMapper;
using FileManagementProject.Entities.Dtos;
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
        private readonly IMapper _mapper;
        public EmployeeManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
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

        public IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges)
        {
            var employees = _manager.Employee.GetAllEmployees(trackChanges);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);

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
            return _manager.Employee.GetOneEmployeeWithDepartment(id,trackChanges);

        }

        public void UpdateOneEmployee(int id, EmployeeDtoForUpdate employeeDto, bool trackChanges)
        {
            //check entity
            var entity = _manager.Employee.GetOneEmployeeById(id, trackChanges);
            if (entity is null)
                throw new EmployeeNotFoundException(id);

            //Mapping
            //entity.EmployeeFirstName = employee.EmployeeFirstName;
            //entity.EmployeeLastName = employee.EmployeeLastName;
            //entity.DepartmentId = employee.DepartmentId;

            //AutoMapping
            entity = _mapper.Map<Employee>(employeeDto);

            _manager.Employee.Update(entity);
            _manager.Save();


        }
    }
}
