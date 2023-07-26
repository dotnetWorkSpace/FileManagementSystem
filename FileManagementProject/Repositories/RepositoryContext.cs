using FileManagementProject.Entities.Models;
using FileManagementProject.Repositories.Config;
using Microsoft.EntityFrameworkCore;

namespace FileManagementProject.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
        }
    }
}
