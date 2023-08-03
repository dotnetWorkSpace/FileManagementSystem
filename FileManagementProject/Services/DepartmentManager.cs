using AutoMapper;
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
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public DepartmentManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public List<DepartmentDto> GetAllDepartments(bool trackChanges)
        {
            var departments = _manager.Department.GetAllDepartments(trackChanges);
            return _mapper.Map<List<DepartmentDto>>(departments);
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

        public void UpdateOneDepartment(int id, DepartmentDtoForUpdate departmentDto, bool trackChanges)
        {
            var entity = _manager.Department.GetDepartmentWithChildren(id, trackChanges);
            if (entity is null)
                throw new DepartmentNotFoundException(id);

            entity = _mapper.Map<Department>(departmentDto);

            _manager.Department.Update(entity);
            _manager.Save();
        }

  
    }
}
