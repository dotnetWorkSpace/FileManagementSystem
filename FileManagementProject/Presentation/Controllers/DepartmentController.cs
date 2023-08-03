using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileManagementProject.Entities;
using Microsoft.EntityFrameworkCore;
using FileManagementProject.Entities.Models;
using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Contracts;
using FileManagementProject.Repositories.EFCore;
using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Services.Contracts;
using FileManagementProject.Entities.Exceptions;

namespace FileManagementProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public DepartmentController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {

                var department = _manager.DepartmentService.GetAllDepartments(false);

                return Ok(department);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetDepartmentWithChildren([FromRoute(Name = "id")] int id)
        {

                var department = _manager.DepartmentService.GetDepartmentWithChildren(id, false);

                var departmentDto = _manager.DepartmentService.MaptoDtoWithChildren(department);

                return Ok(departmentDto);

        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneDepartment([FromRoute(Name = "id")] int id, [FromBody] Department department)
        {

                var entity = _manager
                    .DepartmentService
                    .GetDepartmentWithChildren(id, true);


                if (id != (int)department.DepartmentId)
                    return BadRequest();

                entity.DepartmentName = department.DepartmentName;


                return Ok("Department updated successfully.");


        }


    }
}
