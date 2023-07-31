using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileManagementProject.Entities;
using Microsoft.EntityFrameworkCore;
using FileManagementProject.Entities.Models;
using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Contracts;
using FileManagementProject.Repositories.EFCore;
using FileManagementProject.Repositories.Contracts;

namespace FileManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepositoryManager _manager;

        public DepartmentController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllDepartments() 
        {
            try
            {
                var department = _manager.Department.GetAllDepartments(false);

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
                var department = _manager.Department.GetDepartmentWithChildren(id, false);

                if (department is null)
                    return NotFound(); // 404

                var departmentDto = _manager.Department.MaptoDtoWithChildren(department);

                return Ok(departmentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }


        [HttpPost]
        public IActionResult CreateDepartment([FromBody] Department department)
        {
            try
            {
                if (department is null)
                    return BadRequest(department);

                _manager.Department.Create(department);
                _manager.Save();

                return Ok("Department created successfully.");


            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error: " + ex.Message);

            }

        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateDepartment([FromRoute(Name = "id")] int id, [FromBody] Department department)
        {
            try
            {
                var entity = _manager
                    .Department
                    .GetDepartmentWithChildren(id, true);

                if (entity is null)
                    return NotFound();

                if (id != (int)department.DepartmentId)
                    return BadRequest();

                entity.DepartmentName = (string)department.DepartmentName;

                _manager.Save();


                return Ok("Department updated successfully.");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteDepartment([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _manager
                    .Department
                    .GetDepartmentWithChildren(id, false);

                if (entity is null)
                    return NotFound();

                _manager.Department.Delete(entity);
                _manager.Save();


                return Ok("Department deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

    }
}
