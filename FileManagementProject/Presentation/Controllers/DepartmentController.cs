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
            try
            {
                var department = _manager.DepartmentService.GetAllDepartments(false);

                return Ok(department);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDepartmentWithChildren([FromRoute(Name = "id")] int id)
        {
            try
            {
                var department = _manager.DepartmentService.GetDepartmentWithChildren(id, false);

                if (department is null)
                    return NotFound(); // 404

                var departmentDto = _manager.DepartmentService.MaptoDtoWithChildren(department);

                return Ok(departmentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneDepartment([FromRoute(Name = "id")] int id, [FromBody] Department department)
        {
            try
            {
                var entity = _manager
                    .DepartmentService
                    .GetDepartmentWithChildren(id, true);

                if (entity is null)
                    return NotFound();

                if (id != (int)department.DepartmentId)
                    return BadRequest();

                entity.DepartmentName = department.DepartmentName;


                return Ok("Department updated successfully.");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }

        }


    }
}
