using FileManagementProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManagementProject.Repositories.Config
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(


            new Department
            {
                DepartmentId = 0,
                DepartmentName = "Director",
                ParentDepartmentId = null 
               
            },


            new Department
            {
                DepartmentId = 1,
                DepartmentName = "Purchasing Department",
                ParentDepartmentId = 0,
            },

            new Department
            {
                DepartmentId = 2,
                DepartmentName = "Purchasing Manager",
                ParentDepartmentId = 1,
            },

            new Department
            {
                DepartmentId = 3,
                DepartmentName = "Purchasing Personnel",
                ParentDepartmentId = 2,
            },

            new Department
            {
                DepartmentId = 4,
                DepartmentName = "Accounting Department",
                ParentDepartmentId = 0,
            },

            new Department
            {
                DepartmentId = 5,
                DepartmentName = "Accounting Chief",
                ParentDepartmentId = 4,
            },

            new Department
            {
                DepartmentId = 6,
                DepartmentName = "Accounting Personnel",
                ParentDepartmentId = 5,
            },

            new Department
            {
                DepartmentId = 7,
                DepartmentName = "Sales Department",
                ParentDepartmentId = 0,
            },

            new Department
            {
                DepartmentId = 8,
                DepartmentName = "Sales Chief",
                ParentDepartmentId = 7,
            },

            new Department
            {
                DepartmentId = 9,
                DepartmentName = "Sales Personnel",
                ParentDepartmentId = 8,
            });
        }
    }
}
