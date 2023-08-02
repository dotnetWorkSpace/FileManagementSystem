namespace FileManagementProject.Services.Contracts
{
    public interface IServiceManager
    {
        IEmployeeService EmployeeService { get; }
        IDepartmentService DepartmentService { get; }
    }
}
