using Microsoft.AspNetCore.Mvc;
using VoceaUniversitatii.Services.StudyProgramService;
using VoceaUniversitatiiDataModels.Models;
using VoceaUniversitatiiDataModels.Models.DTOs.StudyProgramDTOs;

namespace VoceaUniversitatii.Controllers;

[ApiController]
[Route("[controller]")]
public class StudyProgramsController : ControllerBase
{
    private readonly IStudyProgramService _studyProgramService;

    public StudyProgramsController(IStudyProgramService studyProgramService)
    {
        _studyProgramService = studyProgramService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<StudyProgram>>> GetAllStudyPrograms()
    {
        var result = await _studyProgramService.GetAllStudyProgramsAsync();
        if (result is null)
        {
            return NotFound("Didn't find the list of studyPrograms.");
        }
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<StudyProgram>> GetSingleStudyProgram(long id)
    {
        var result = await _studyProgramService.GetSingleStudyProgramAsync(id);
        if (result is null)
        {
            return NotFound("Didn't find the studyProgram");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<StudyProgramSendDTO>>> AddStudyProgram(StudyProgramCreateDTO studyProgram)
    {
        var result = await _studyProgramService.AddStudyProgramAsync(studyProgram);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<StudyProgramSendDTO>>> UpdateStudyProgram(StudyProgramUpdateDTO request)
    {
        var result = await _studyProgramService.UpdateStudyProgramAsync(request);
        if (result is null)
        {
            return NotFound("Didn't find the studyProgram");
        }

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<StudyProgramSendDTO>>> DeleteStudyProgram(long id)
    {
        var result = await _studyProgramService.DeleteStudyProgramAsync(id);
        if (result is null)
        {
            return NotFound("Didn't find the studyProgram");
        }

        return Ok(result);
    }
    
}