namespace FileManagementProject.Entities.Exceptions
{
    //sealed hiçbir şekilde kalıtıma izin vermez
    public sealed class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(int id) : base($"The employee with id : {id} not found.")
        {
        }
    }
}
