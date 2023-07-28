using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;

namespace FileManagementProject.Repositories.Contracts
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        List<DepartmentDto> GetAllDepartments(bool trackChanges);
        Department GetDepartmentWithChildren(int id, bool trackChanges);
        DepartmentDto MaptoDtoWithChildren (Department department);
        void UpdateOneDepartment(Department department);
        void DeleteOneDepartment(Department department);
    }
}
