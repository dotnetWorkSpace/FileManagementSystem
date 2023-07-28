using FileManagementProject.Entities.Contracts;
using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;
using FileManagementProject.Repositories.Contracts;

namespace FileManagementProject.Repositories.EFCore
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(RepositoryContext context) : base(context)
        {
        }

        void IDepartmentRepository.DeleteOneDepartment(Department department) => Delete(department);

        public List<DepartmentDto> GetAllDepartments(bool trackChanges)
        {
            var departments = _context.Departments;
            var departmentTree = new List<DepartmentDto>();
            var departmentLookup = new Dictionary<int, DepartmentDto>();

            foreach (var department in departments)
            {
                var dto = new DepartmentDto
                {
                    DepartmentId = (int)department.DepartmentId,
                    DepartmentName = department.DepartmentName,
                    Children = new List<DepartmentDto>()
                };

                departmentLookup[(int)department.DepartmentId] = dto;

                if (department.ParentDepartmentId == null)
                {
                    departmentTree.Add(dto);
                }
                else
                {
                    if (departmentLookup.TryGetValue(department.ParentDepartmentId.Value, out var parent))
                    {
                        parent.Children.Add(dto);
                    }
                }
            }
            return departmentTree;
        }

        void IDepartmentRepository.UpdateOneDepartment(Department department) => Update(department);

        public Department GetDepartmentWithChildren(int id, bool trackChanges)
        {
            var department = _context.Departments
                    .Where(d => d.DepartmentId == id)
                    .SingleOrDefault();

            if (department is null)
                return null;

            return department;
        }

        public DepartmentDto MaptoDtoWithChildren(Department department)
        {
            var departmentDto = new DepartmentDto
            {
                DepartmentId = (int)department.DepartmentId,
                DepartmentName = department.DepartmentName,
                Children = new List<DepartmentDto>()
            };

            var childDepartments = _context.Departments
                .Where(d => d.ParentDepartmentId == department.DepartmentId)
                .ToList();

            if (childDepartments != null)
            {
                foreach (var childDepartment in childDepartments)
                {
                    var childDto = MaptoDtoWithChildren(childDepartment);
                    departmentDto.Children.Add(childDto);
                }
            }

            return departmentDto;
        }
    }
}