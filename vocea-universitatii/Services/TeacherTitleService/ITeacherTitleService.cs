using VoceaUniversitatii.Models.DTOs.TeacherDTOs.TeacherTitleDTOs;

namespace VoceaUniversitatii.Services.TeacherTitleService;

public interface ITeacherTitleService
{
    Task<List<TeacherTitleSendDTO>> GetAllTeacherTitles();

    Task<TeacherTitleSendDTO> AddTeacherTitle(TeacherTitleCreateDTO teacherTitle);

    Task<TeacherTitleSendDTO> UpdateTeacherTitle(TeacherTitleUpdateDTO request);

    Task<List<TeacherTitleSendDTO>> DeleteTeacherTitle(long id);
}