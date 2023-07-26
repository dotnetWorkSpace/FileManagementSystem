namespace FileManagementProject.Entities.Models
{
    public class File
    {
        public int FileId { get; set; }
        public String FileName { get; set; }
        public String FilePath { get; set; }
        public int OwnerId { get; set; }
        public DateTime UploadTime { get; set; } = DateTime.Now;
        public int DepartmentId { get; set; }
    }
}
