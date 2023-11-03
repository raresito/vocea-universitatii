using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using vocea_universitatii.Models;
using vocea_universitatii.Services.DepartmentService;

namespace vocea_universitatii.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Department>>> GetAllDepartments()
    {
        var result = await _departmentService.GetAllDepartments();
        if (result is null)
        {
            return NotFound("Didn't find the list of departments.");
        }
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Department>> GetSingleDepartment(int id)
    {
        var result = await _departmentService.GetSingleDepartment(id);
        if (result is null)
        {
            return NotFound("Didn't find the department");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<Department>>> AddDepartment(Department department)
    {
        var result = await _departmentService.AddDepartment(department);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Department>>> UpdateDepartment(int id, Department request)
    {
        var result = await _departmentService.UpdateDepartment(id, request);
        if (result is null)
        {
            return NotFound("Didn't find the department");
        }

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Department>>> DeleteDepartment(int id)
    {
        var result = await _departmentService.DeleteDepartment(id);
        if (result is null)
        {
            return NotFound("Didn't find the department");
        }

        return Ok(result);
    }
    
}