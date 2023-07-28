using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;
using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Repositories.EFCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryManager _manager;

        public EmployeeController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllEmployee() 
        {
            try
            {
                var employees = _manager.Employee.GetAllEmployees(false);
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
                var employees = _manager
                    .Employee
                    .GetOneEmployeesById(id, false);

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
        public IActionResult GetEmployeeWithDepartmentName([FromRoute(Name = "id")] int id)
        {
            try
            {
                var employee = _manager.Employee.GetOneEmployeeWithDepartment(id, false);


                var employeeDto = new EmployeeDto
                { 
                    EmployeeId = employee.EmployeeId,
                    EmployeeFirstName = employee.EmployeeFirstName,
                    EmployeeLastName = employee.EmployeeLastName,
                    DepartmentName = employee.Department?.DepartmentName // Çalışanın bağlı olduğu Departmanın adını alır
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
