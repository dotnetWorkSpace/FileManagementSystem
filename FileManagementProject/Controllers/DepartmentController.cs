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
        public ActionResult GetAllDepartments() 
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
        public ActionResult GetDepartmentWithChildren([FromRoute(Name = "id")] int id)
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
        public ActionResult CreateDepartment([FromBody] DepartmentDto departmentDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var new_department = new Department
                {
                    DepartmentName = departmentDto.DepartmentName,
                    DepartmentId = departmentDto.DepartmentId,
                    ParentDepartmentId = departmentDto.ParentDepartmentId,
                }
                _context.Departments.Add(new_department);
                _context.SaveChanges();

                return Ok("Department created successfully.");


            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error: " + ex.Message);

            }

        }
        [HttpPut("{id:int}")]
        public ActionResult UpdateDepartment([FromRoute(Name = "id")] int id, [FromBody] DepartmentDto departmentDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var department = _context.Departments.FirstOrDefault(d => d.DepartmentId == id);

                if (department == null)
                    return NotFound();


                department.DepartmentName = departmentDto.DepartmentName;
                department.DepartmentId = departmentDto.DepartmentId;
                department.ParentDepartmentId = departmentDto.ParentDepartmentId;
                _context.SaveChanges();


                return Ok("Department updated successfully.");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }

        }
        [HttpDelete("{id:int}")]
        public ActionResult DeleteDepartment([FromRoute(Name = "id")] int id)
        {
            try
            {
                var department = _context.Departments.FirstOrDefault(d => d.DepartmentId == id);

                if (department == null)
                    return NotFound();

                _context.Departments.Remove(department);

                _context.SaveChanges();


                return Ok("Department deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

    }
}
