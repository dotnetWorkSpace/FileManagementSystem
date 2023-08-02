﻿using FileManagementProject.Entities.Models;
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
            if(entity is null)
            {
                string message = $"The employee with id:{id} could not found";
                _logger.LogInformation(message);
                throw new Exception(message);
            }
                

            _manager.Employee.DeleteOneEmployee(entity);
            _manager.Save();
        }

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges)
        {
            return _manager.Employee.GetAllEmployees(trackChanges);

        }

        public Employee GetOneEmployeeById(int id, bool trackChanges)
        {
            return _manager.Employee.GetOneEmployeeById(id, trackChanges);
        }

        public Employee GetOneEmployeeWithDepartment(int id, bool trackChanges)
        {
            return _manager.Employee.GetOneEmployeeWithDepartment(id, trackChanges);
        }

        public void UpdateOneEmployee(int id, Employee employee, bool trackChanges)
        {
            //check entity
            var entity = _manager.Employee.GetOneEmployeeById(id, trackChanges);
            if(entity is null)
                throw new Exception($"Employee with id:{id} could not found.");

            if(employee is null)
                throw new ArgumentNullException(nameof(employee));

            entity.EmployeeFirstName = employee.EmployeeFirstName;
            entity.EmployeeLastName = employee.EmployeeLastName;
            entity.DepartmentId = employee.DepartmentId;

            _manager.Employee.Update(entity);
            _manager.Save();


        }
    }
}
