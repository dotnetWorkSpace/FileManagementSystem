namespace FileManagementProject.Entities.Exceptions
{
    public sealed class DepartmentNotFoundException : NotFoundException
    {
        public DepartmentNotFoundException(int id) : base($"The department with id : {id} not found.")
        {
        }
    }
}
