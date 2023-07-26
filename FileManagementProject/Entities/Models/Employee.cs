namespace FileManagementProject.Entities.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public String? EmployeeFirstName { get; set; }
        public String? EmployeeLastName { get; set; }
        public String? EmployeeEmail { get; set; }
        public String? EmployeePassword { get; set; }
        public int EmployeeDepartmentId { get; set; }
        public int? EmployeeManagerId { get; set; }

    }
}
