using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;
using FileManagementProject.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FileManagementProject.Repositories.EFCore
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneEmployee(Employee employee) => Create(employee);

        public void DeleteOneEmployee(Employee employee) => Delete(employee);

        public IQueryable<Employee> GetAllEmployees(bool trackChanges) =>
            FindAll(trackChanges);


        public Employee GetOneEmployeeById(int id, bool trackChanges) =>
            FindByCondition(b => b.EmployeeId.Equals(id), trackChanges)
            .SingleOrDefault();

        public Employee GetOneEmployeeWithDepartment(int id, bool trackChanges)
        {
            var employee = _context.Employees
                    .Include(e => e.Department) 
                    .Where(e => e.EmployeeId.Equals(id))
                    .SingleOrDefault();

            if (employee is null)
                return null;

            return employee;
        }

        public void UpdateOneEmployee(Employee employee) => Update(employee);

    }
}
