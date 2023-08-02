using FileManagementProject.Entities.Models;

namespace FileManagementProject.Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
        Employee GetOneEmployeeById (int id, bool trackChanges);
        Employee GetOneEmployeeWithDepartment(int id, bool trackChanges);
        Employee CreateOneEmployee (Employee employee);
        void UpdateOneEmployee (int id, Employee employee, bool trackChanges);
        void DeleteOneEmployee (int id, bool trackChanges);
    }
}
