using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Exceptions;
using FileManagementProject.Entities.Models;
using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Services.Contracts;

namespace FileManagementProject.Services
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IRepositoryManager _manager;

        public DepartmentManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public List<DepartmentDto> GetAllDepartments(bool trackChanges)
        {
            return _manager.Department.GetAllDepartments(trackChanges);
        }

        public Department GetDepartmentWithChildren(int id, bool trackChanges)
        {
            var department = _manager.Department.GetDepartmentWithChildren(id, trackChanges);
            if(department is null)
                throw new DepartmentNotFoundException(id);
            return department;
        }

        public DepartmentDto MaptoDtoWithChildren(Department department)
        {
            return _manager.Department.MaptoDtoWithChildren(department);
        }

        public void UpdateOneDepartment(int id, Department department, bool trackChanges)
        {
            var entity = _manager.Department.GetDepartmentWithChildren(id, trackChanges);
            if (entity is null)
                throw new DepartmentNotFoundException(id);

            entity.DepartmentName = department.DepartmentName;
            entity.DepartmentId = department.DepartmentId;

            _manager.Department.Update(entity);
            _manager.Save();
        }
    }
}
