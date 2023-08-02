using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;
using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Repositories.EFCore;
using FileManagementProject.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public EmployeeController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("/employees")]
        public IActionResult GetAllEmployee()
        {
            try
            {
                var employees = _manager.EmployeeService.GetAllEmployees(false);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("/employee{id:int}")]
        public IActionResult GetOneEmployee([FromRoute(Name = "id")] int id)
        {
            try
            {
                var employees = _manager
                    .EmployeeService
                    .GetOneEmployeeById(id, false);

                if (employees is null)
                    return NotFound();

                return Ok(employees);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        [HttpGet("employee/{id:int}/department")]
        public IActionResult GetEmployeeWithDepartmentName([FromRoute(Name = "id")] int id)
        {
            try
            {
                var employee = _manager.EmployeeService.GetOneEmployeeWithDepartment(id, false);


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


        [HttpPost]
        public IActionResult CreateOneEmployee([FromBody] Employee employee)
        {
            try
            {
                if (employee is null)
                    return BadRequest(employee);

                _manager.EmployeeService.CreateOneEmployee(employee);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateEmployee([FromRoute(Name = "id")] int id, [FromBody] Employee employee)
        {
            try
            {
                if(employee is null)
                    return BadRequest(employee);

                _manager.EmployeeService.UpdateOneEmployee(id, employee, true);
                return NoContent();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("~/api/employee/delete/{id:int}")]
        public IActionResult DeleteEmployee([FromRoute(Name = "id")] int id)
        {
            try
            {

                _manager.EmployeeService.DeleteOneEmployee(id, false);


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
