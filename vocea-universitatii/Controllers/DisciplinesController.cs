using Microsoft.AspNetCore.Mvc;
using vocea_universitatii.Models;
using vocea_universitatii.Models.DTOs.DisciplineDTOs;
using vocea_universitatii.Services.DisciplineService;

namespace vocea_universitatii.Controllers;

[ApiController]
[Route("[controller]")]
public class DisciplinesController : ControllerBase
{
    private readonly IDisciplineService _disciplineService;

    public DisciplinesController(IDisciplineService disciplineService)
    {
        _disciplineService = disciplineService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Discipline>>> GetAllDisciplines()
    {
        var result = await _disciplineService.GetAllDisciplinesAsync();
        if (result is null)
        {
            return NotFound("Didn't find the list of disciplines.");
        }
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Discipline>> GetSingleDiscipline(long id)
    {
        var result = await _disciplineService.GetSingleDisciplineAsync(id);
        if (result is null)
        {
            return NotFound("Didn't find the discipline");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<DisciplineSendDTO>>> AddDiscipline(DisciplineCreateDTO discipline)
    {
        var result = await _disciplineService.AddDisciplineAsync(discipline);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<DisciplineSendDTO>>> UpdateDiscipline(DisciplineUpdateDTO request)
    {
        var result = await _disciplineService.UpdateDisciplineAsync(request);
        if (result is null)
        {
            return NotFound("Didn't find the discipline");
        }

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<DisciplineSendDTO>>> DeleteDiscipline(long id)
    {
        var result = await _disciplineService.DeleteDisciplineAsync(id);
        if (result is null)
        {
            return NotFound("Didn't find the discipline");
        }

        return Ok(result);
    }
}