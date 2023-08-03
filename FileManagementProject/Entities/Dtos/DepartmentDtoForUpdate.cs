namespace FileManagementProject.Entities.Dtos
{
    public record DepartmentDtoForUpdate
    {
        public int DepartmentId { get; init; }
        public String DepartmentName { get; init; }
        public int? ParentDepartmentId { get; init; }
        public List<DepartmentDto>? Children { get; init; }
    }
}

