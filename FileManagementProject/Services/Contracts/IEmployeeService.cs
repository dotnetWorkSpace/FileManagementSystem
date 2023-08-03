using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;

namespace FileManagementProject.Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges);
        Employee GetOneEmployeeById (int id, bool trackChanges);
        Employee GetOneEmployeeWithDepartment(int id, bool trackChanges);
        Employee CreateOneEmployee (Employee employee);
        void UpdateOneEmployee (int id, EmployeeDtoForUpdate employeeDto, bool trackChanges);
        void DeleteOneEmployee (int id, bool trackChanges);
    }
}
