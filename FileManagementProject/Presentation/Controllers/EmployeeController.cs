using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Exceptions;
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
               var employees = _manager.EmployeeService.GetAllEmployees(false);
               return Ok(employees);
        }

        [HttpGet("/employee{id:int}")]
        public IActionResult GetOneEmployee([FromRoute(Name = "id")] int id)
        {
                var employees = _manager
                    .EmployeeService
                    .GetOneEmployeeById(id, false);


                return Ok(employees);

        }



        [HttpGet("employee/{id:int}/department")]
        public IActionResult GetEmployeeWithDepartmentName([FromRoute(Name = "id")] int id)
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


        [HttpPost]
        public IActionResult CreateOneEmployee([FromBody] Employee employee)
        {

                if (employee is null)
                    return BadRequest(employee);

                _manager.EmployeeService.CreateOneEmployee(employee);

                return Ok();

        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateEmployee([FromRoute(Name = "id")] int id, [FromBody] EmployeeDtoForUpdate employeeDto)
        {

                if(employeeDto is null)
                    return BadRequest(employeeDto);

                _manager.EmployeeService.UpdateOneEmployee(id, employeeDto, true);
                return NoContent();


        }

        [HttpDelete]
        [Route("~/api/employee/delete/{id:int}")]
        public IActionResult DeleteEmployee([FromRoute(Name = "id")] int id)
        {


                _manager.EmployeeService.DeleteOneEmployee(id, false);


                return Ok();


        }
    }
}
