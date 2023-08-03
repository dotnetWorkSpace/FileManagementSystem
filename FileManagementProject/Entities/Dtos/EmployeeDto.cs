using FileManagementProject.Entities.Models;

namespace FileManagementProject.Entities.Dtos 
{ 

    public record EmployeeDto
    {
        public int EmployeeId { get; set; }
        public String EmployeeFirstName { get; set; }
        public String EmployeeLastName { get; set; }
        public String DepartmentName { get; set; }
        public int DepartmentId { get; set; }


    }
}
