using FileManagementProject.Entities.Dtos;
using FileManagementProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public EmployeeController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEmployees() 
        {
            try
            {
                var employees = _context.Employees.ToList();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneEmployee([FromRoute(Name = "id")] int id)
        {
            try
            {
                var employees = _context.Employees
                    .Where(e => e.EmployeeId.Equals(id))
                    .SingleOrDefault();

                if (employees is null)
                    return NotFound();

                return Ok(employees);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("department/{id:int}")]
        public IActionResult GetEmployeeWithDepartmentName([FromRoute(Name ="id")]int id)
        {
            try
            {
                var employee = _context.Employees
                    .Include(e => e.Department) // Çalışanın bağlı olduğu Departmanı dahil et
                    .Where(e => e.EmployeeId.Equals(id))
                    .SingleOrDefault();

                if (employee is null)
                    return NotFound();

                var employeeDto = new EmployeeDto
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeFirstName = employee.EmployeeFirstName,
                    EmployeeLastName = employee.EmployeeLastName,
                    DepartmentName = employee.Department?.DepartmentName // Çalışanın bağlı olduğu Departmanın adını al
                };

                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }



    }
}
