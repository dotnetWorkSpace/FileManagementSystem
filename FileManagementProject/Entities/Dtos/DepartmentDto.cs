using FileManagementProject.Entities.Models;

namespace FileManagementProject.Entities.Dtos
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public String DepartmentName { get; set; }
        public int? ParentDepartmentId { get; set; }
        public List<DepartmentDto>? Children { get; set; }
    }
}
