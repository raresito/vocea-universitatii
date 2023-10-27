using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using vocea_universitatii.Services.FacultyService;

namespace vocea_universitatii.Controllers;

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
    public async Task<ActionResult<List<Faculty>>> GetAllFaculties()
    {
        var result = await _facultyService.GetAllFaculties();
        if (result is null)
        {
            return NotFound("Didn't find the list of faculties.");
        }
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Faculty>> GetSingleFaculty(int id)
    {
        var result = await _facultyService.GetSingleFaculty(id);
        if (result is null)
        {
            return NotFound("Didn't find the faculty");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<Faculty>>> AddFaculty(Faculty faculty)
    {
        var result = await _facultyService.AddFaculty(faculty);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Faculty>>> UpdateFaculty(int id, Faculty request)
    {
        var result = await _facultyService.UpdateFaculty(id, request);
        if (result is null)
        {
            return NotFound("Didn't find the faculty");
        }

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Faculty>>> DeleteFaculty(int id)
    {
        var result = await _facultyService.DeleteFaculty(id);
        if (result is null)
        {
            return NotFound("Didn't find the faculty");
        }

        return Ok(result);
    }
    
    
}