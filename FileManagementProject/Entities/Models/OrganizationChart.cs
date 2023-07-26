namespace FileManagementProject.Entities.Models
{
    public class OrganizationChart
    {
        public int OrganizationId { get; set; }
        public String Name { get; set; }
        public int? ParentId { get; set; }
        public List<OrganizationChart> Children { get; set; }
    }
}
