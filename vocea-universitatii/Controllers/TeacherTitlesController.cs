using Microsoft.AspNetCore.Mvc;
using VoceaUniversitatii.Services.TeacherTitleService;
using VoceaUniversitatiiDataModels.Models;
using VoceaUniversitatiiDataModels.Models.DTOs.TeacherDTOs.TeacherTitleDTOs;

namespace VoceaUniversitatii.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherTitlesController : ControllerBase
{
    private readonly ITeacherTitleService _teacherTitleService;

    public TeacherTitlesController(ITeacherTitleService teacherTitleService)
    {
        _teacherTitleService = teacherTitleService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<TeacherTitle>>> GetAllTeacherTitles()
    {
        var result = await _teacherTitleService.GetAllTeacherTitles();
        if (result is null)
        {
            return NotFound("Didn't find the list of teacherTitles.");
        }
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<TeacherTitleSendDTO>>> AddTeacherTitle(TeacherTitleCreateDTO teacherTitle)
    {
        var result = await _teacherTitleService.AddTeacherTitle(teacherTitle);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<TeacherTitleSendDTO>>> UpdateTeacherTitle(TeacherTitleUpdateDTO request)
    {
        var result = await _teacherTitleService.UpdateTeacherTitle(request);
        if (result is null)
        {
            return NotFound("Didn't find the teacherTitle");
        }
    
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<TeacherTitleSendDTO>>> DeleteTeacherTitle(long id)
    {
        var result = await _teacherTitleService.DeleteTeacherTitle(id);
        // if (!result.Any()) { return NoContent(); }
        if (result is null) { return NotFound("Didn't find the teacherTitle"); }
    
        return Ok(result);
    }
}