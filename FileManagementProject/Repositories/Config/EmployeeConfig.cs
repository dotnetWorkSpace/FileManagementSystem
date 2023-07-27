using FileManagementProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManagementProject.Repositories.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeFirstName = "Enes",
                    EmployeeLastName = "Büyükbaş",
                    EmployeeEmail = "enes_bykbss@hotmail.com",
                    EmployeePassword = "1234",
                    DepartmentId = 0,
                    EmployeeManagerId = 0
                },
                new Employee
                {
                    EmployeeId = 2,
                    EmployeeFirstName = "Emre",
                    EmployeeLastName = "Büyük",
                    EmployeeEmail = "enes_buyukbas@hotmail.com",
                    EmployeePassword = "12345",
                    DepartmentId = 1
                },
                new Employee
                {
                    EmployeeId = 3,
                    EmployeeFirstName = "Beyza",
                    EmployeeLastName = "Yüksel",
                    EmployeeEmail = "beyzayuksel0111@gmail.com",
                    EmployeePassword = "123456789",
                    DepartmentId = 2
                }
                );
        }
    }
}
