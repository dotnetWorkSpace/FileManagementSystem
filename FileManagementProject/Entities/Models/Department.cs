using FileManagementProject.Entities.Dtos;

namespace FileManagementProject.Entities.Models
{
    public class Department
    {
        public int? DepartmentId { get; set; } 
        public String DepartmentName { get; set; }
        public int? ParentDepartmentId { get; set; }
        public List<Employee> Employees { get; set; }

    }
}
