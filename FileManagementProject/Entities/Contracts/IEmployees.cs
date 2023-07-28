namespace FileManagementProject.Entities.Contracts
{
    public interface IEmployees
    {
        
        Result<Employees> GetOneEmployee(int id); //düzeltilmesi gerekiyor -Result
        List<Employees> Get();


    }
}
