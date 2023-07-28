using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;

namespace FileManagementProject.Entities.Contracts
{
    public interface IDepartment
    {
        Result<DepartmentDto> GetAllDepartments(int DepartmentId); //düzeltilmesi gerekiyor -Result
        List<Department> Get();
    }
}
