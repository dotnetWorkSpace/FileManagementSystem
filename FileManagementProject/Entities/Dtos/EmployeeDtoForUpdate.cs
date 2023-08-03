namespace FileManagementProject.Entities.Dtos
{
    public record EmployeeDtoForUpdate
    {
            public int EmployeeId { get; init; }
            public String EmployeeFirstName { get; init; }
            public String EmployeeLastName { get; init; }
            public String DepartmentName { get; init; }

    }
}
