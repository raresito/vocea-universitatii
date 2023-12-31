﻿using Microsoft.AspNetCore.Mvc;
using VoceaUniversitatii.Services.TeacherService;
using VoceaUniversitatiiDataModels.Models;
using VoceaUniversitatiiDataModels.Models.DTOs.TeacherDTOs;

namespace VoceaUniversitatii.Controllers;

[ApiController]
[Route("[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeachersController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Teacher>>> GetAllTeachers()
    {
        var result = await _teacherService.GetAllTeachers();
        if (result is null)
        {
            return NotFound("Didn't find the list of teachers.");
        }
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Teacher>> GetSingleTeacher(long id)
    {
        var result = await _teacherService.GetSingleTeacher(id);
        if (result is null)
        {
            return NotFound("Didn't find the teacher");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<TeacherSendDTO>>> AddTeacher(TeacherCreateDTO teacher)
    {
        var result = await _teacherService.AddTeacher(teacher);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<TeacherSendDTO>>> UpdateTeacher(TeacherUpdateDTO request)
    {
        var result = await _teacherService.UpdateTeacher(request);
        if (result is null)
        {
            return NotFound("Didn't find the teacher");
        }
    
        return Ok(result);
    }
    
    [HttpPut("title")]
    public async Task<ActionResult<List<TeacherSendDTO>>> UpdateTeacherTitle(TeacherUpdateDTO request)
    {
        var result = await _teacherService.UpdateTeacher(request);
        if (result is null)
        {
            return NotFound("Didn't find the teacher");
        }
        return Ok(result);
    }
    
    [HttpPut("addTeacherDepartmentMembership")]
    public async Task<ActionResult<TeacherSendDTO>> AddTeacherDepartmentMembership(long teacherId, long departmentId)
    {
        var result = await _teacherService.AddTeacherDepartmentMembership(teacherId, departmentId);
        if (result is null)
        {
            return NotFound("Couldn't add the department to the teacher");
        }
    
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<TeacherSendDTO>>> DeleteTeacher(long id)
    {
        var result = await _teacherService.DeleteTeacher(id);
        if (!result.Any()) { return NoContent(); }
        if (result is null) { return NotFound("Didn't find the teacher"); }
    
        return Ok(result);
    }
}