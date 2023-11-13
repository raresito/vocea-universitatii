using Microsoft.AspNetCore.Mvc;
using vocea_universitatii.Models;
using vocea_universitatii.Models.DTOs;

namespace vocea_universitatii.Services.TeacherTitlesService;

public interface ITeacherTitleService
{
    Task<List<TeacherTitleSendDTO>> GetAllTeacherTitles();

    Task<TeacherTitleSendDTO> AddTeacherTitle(TeacherTitleCreateDTO teacherTitle);

    Task<TeacherTitleSendDTO> UpdateTeacherTitle(TeacherTitleUpdateDTO request);

    Task<List<TeacherTitleSendDTO>> DeleteTeacherTitle(long id);
}