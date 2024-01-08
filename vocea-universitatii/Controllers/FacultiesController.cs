using Microsoft.AspNetCore.Mvc;
using VoceaUniversitatii.Services.FacultyService;
using VoceaUniversitatiiDataModels.Models.DTOs.FacultyDTOs;

namespace VoceaUniversitatii.Controllers;

[ApiController]
[Route("[controller]")]
public class FacultiesController : ControllerBase
{
    
    private readonly IFacultyService _facultyService;

    public FacultiesController(IFacultyService facultyService)
    {
        _facultyService = facultyService;
    }

    [HttpGet]
    public async Task<ActionResult<List<FacultySendDTO>>> GetAllFaculties()
    {
        var result = await _facultyService.GetAllFaculties();
        if (!result.Any()) return NotFound("Didn't find the list of faculties.");
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<FacultySendDTO>> GetSingleFaculty(long id)
    {
        var faculty = await _facultyService.GetSingleFaculty(id);
        if (faculty is null) return NotFound("Didn't find the faculty");
        return Ok(faculty);
    }

    [HttpPost]
    public async Task<ActionResult<FacultySendDTO>> AddFaculty(FacultyCreateDTO faculty)
    {
        var result = await _facultyService.AddFaculty(faculty);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<FacultySendDTO>>> UpdateFaculty(FacultyUpdateDTO request)
    {
        var result = await _facultyService.UpdateFaculty(request);
        if (result is null)
        {
            return NotFound("Didn't find the faculty");
        }

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<FacultySendDTO>>> DeleteFaculty(long id)
    {
        var result = await _facultyService.DeleteFaculty(id);
        if (result is null)
        {
            return NotFound("Didn't find the faculty");
        }
        return Ok(result);
    }
    
    
}