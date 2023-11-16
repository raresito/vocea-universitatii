using Microsoft.AspNetCore.Mvc;
using VoceaUniversitatii.Models;
using VoceaUniversitatii.Models.DTOs.DepartmentDTOs;
using VoceaUniversitatii.Services.DepartmentService;

namespace VoceaUniversitatii.Controllers;

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
    public async Task<ActionResult<Department>> GetSingleDepartment(long id)
    {
        var result = await _departmentService.GetSingleDepartment(id);
        if (result is null)
        {
            return NotFound("Didn't find the department");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<DepartmentSendDTO>>> AddDepartment(DepartmentCreateDTO department)
    {
        var result = await _departmentService.AddDepartment(department);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<DepartmentSendDTO>>> UpdateDepartment(DepartmentUpdateDTO request)
    {
        var result = await _departmentService.UpdateDepartment(request);
        if (result is null)
        {
            return NotFound("Didn't find the department");
        }

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<DepartmentSendDTO>>> DeleteDepartment(long id)
    {
        var result = await _departmentService.DeleteDepartment(id);
        if (result is null)
        {
            return NotFound("Didn't find the department");
        }

        return Ok(result);
    }
    
}