using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;

namespace FileManagementProject.Services.Contracts
{
    public interface IDepartmentService
    {
        List<DepartmentDto> GetAllDepartments(bool trackChanges);
        Department GetDepartmentWithChildren(int id, bool trackChanges);
        DepartmentDto MaptoDtoWithChildren(Department department);
        void UpdateOneDepartment(int id, Department department, bool trackChanges);
    }
}
