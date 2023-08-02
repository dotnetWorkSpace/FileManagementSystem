using FileManagementProject.Entities.Models;

namespace FileManagementProject.Repositories.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        IQueryable<Employee> GetAllEmployees(bool trackChanges);
        Employee GetOneEmployeeById(int id, bool trackChanges);
        Employee GetOneEmployeeWithDepartment(int id, bool trackChanges);
        void CreateOneEmployee (Employee employee);
        void UpdateOneEmployee(Employee employee);
        void DeleteOneEmployee(Employee employee);
    }
}
