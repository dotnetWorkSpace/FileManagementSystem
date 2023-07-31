using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;

namespace FileManagementProject.Entities.Contracts
{
    public interface IDepartment
    {
        Result<DepartmentDto> GetDepartmentById(int DepartmentId);
        List<Department> Get();
    }
}
