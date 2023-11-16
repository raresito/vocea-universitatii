using Microsoft.AspNetCore.Mvc;
using VoceaUniversitatii.Models;
using VoceaUniversitatii.Models.DTOs.StudentCohortDTOs;
using VoceaUniversitatii.Services.StudentCohortService;

namespace VoceaUniversitatii.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentCohortsController : ControllerBase
{
    private readonly IStudentCohortService _StudentCohortService;

    public StudentCohortsController(IStudentCohortService StudentCohortService)
    {
        _StudentCohortService = StudentCohortService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<StudentCohort>>> GetAllStudentCohorts()
    {
        var result = await _StudentCohortService.GetAllStudentCohortsAsync();
        if (result is null)
        {
            return NotFound("Didn't find the list of StudentCohorts.");
        }
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<StudentCohort>> GetSingleStudentCohort(long id)
    {
        var result = await _StudentCohortService.GetSingleStudentCohortAsync(id);
        if (result is null)
        {
            return NotFound("Didn't find the StudentCohort");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<StudentCohortSendDTO>>> AddStudentCohort(StudentCohortCreateDTO StudentCohort)
    {
        var result = await _StudentCohortService.AddStudentCohortAsync(StudentCohort);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<StudentCohortSendDTO>>> UpdateStudentCohort(StudentCohortUpdateDTO request)
    {
        var result = await _StudentCohortService.UpdateStudentCohortAsync(request);
        if (result is null)
        {
            return NotFound("Didn't find the StudentCohort");
        }

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<StudentCohortSendDTO>>> DeleteStudentCohort(long id)
    {
        var result = await _StudentCohortService.DeleteStudentCohortAsync(id);
        if (result is null)
        {
            return NotFound("Didn't find the StudentCohort");
        }

        return Ok(result);
    }
}