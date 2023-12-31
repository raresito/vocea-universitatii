﻿using VoceaUniversitatiiDataModels.Models.DTOs.TeacherDTOs;

namespace VoceaUniversitatii.Services.TeacherService;

public interface ITeacherService
{
    Task<List<TeacherSendDTO>> GetAllTeachers();
    
    Task<TeacherSendDTO> GetSingleTeacher(long id);

    Task<TeacherSendDTO> AddTeacher(TeacherCreateDTO teacher);

    Task<TeacherSendDTO> AddTeacherDepartmentMembership(long teacherId, long departmentId);

    Task<List<TeacherSendDTO>> UpdateTeacher(TeacherUpdateDTO request);
    
    Task<List<TeacherSendDTO>> DeleteTeacher(long id);
}