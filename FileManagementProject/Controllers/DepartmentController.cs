﻿using FileManagementProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileManagementProject.Entities;
using Microsoft.EntityFrameworkCore;
using FileManagementProject.Entities.Models;
using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Contracts;

namespace FileManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public DepartmentController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAllDepartments() 
        {
            try
            {
                var departments = _context.Departments.ToList();

                var departmentTree = new List<DepartmentDto>();
                var departmentLookup = new Dictionary<int, DepartmentDto>();

                foreach (var department in departments)
                {
                    var dto = new DepartmentDto
                    {
                        DepartmentId = (int)department.DepartmentId,
                        DepartmentName = department.DepartmentName,
                        Children = new List<DepartmentDto>()
                    };

                    departmentLookup[(int)department.DepartmentId] = dto;

                    if (department.ParentDepartmentId == null)
                    {
                        departmentTree.Add(dto);
                    }
                    else
                    {
                        if (departmentLookup.TryGetValue(department.ParentDepartmentId.Value, out var parent))
                        {
                            parent.Children.Add(dto);
                        }
                    }
                }

                return Ok(departmentTree);
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
                var department = _context.Departments
                    .Where(d => d.DepartmentId == id)
                    .SingleOrDefault();

                if (department is null)
                    return NotFound(); // 404

                var departmentDto = MapToDtoWithChildren(department);

                return Ok(departmentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
        private DepartmentDto MapToDtoWithChildren(Department department)
        {
            var departmentDto = new DepartmentDto
            {
                DepartmentId = (int)department.DepartmentId,
                DepartmentName = department.DepartmentName,
                Children = new List<DepartmentDto>()
            };

            var childDepartments = _context.Departments
                .Where(d => d.ParentDepartmentId == department.DepartmentId)
                .ToList();

            if (childDepartments != null)
            {
                foreach (var childDepartment in childDepartments)
                {
                    var childDto = MapToDtoWithChildren(childDepartment);
                    departmentDto.Children.Add(childDto);
                }
            }

            return departmentDto;
        }



    }
}