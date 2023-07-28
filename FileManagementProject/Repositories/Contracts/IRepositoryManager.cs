namespace FileManagementProject.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IEmployeeRepository Employee { get; }
        IDepartmentRepository Department { get; }
        void Save();
    }
}
