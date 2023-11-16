using VoceaUniversitatii.Models;
using VoceaUniversitatii.Models.DTOs.StudyProgramDTOs;

namespace VoceaUniversitatii.Services.StudyProgramService;

public interface IStudyProgramService
{
    Task<List<StudyProgramSendDTO>> GetAllStudyProgramsAsync();
    
    Task<StudyProgramSendDTO> GetSingleStudyProgramAsync(long id);
    
    Task<List<StudyProgramSendDTO>> AddStudyProgramAsync(StudyProgramCreateDTO studyProgram);
    
    Task<StudyProgramSendDTO> UpdateStudyProgramAsync(StudyProgramUpdateDTO request);
    
    Task<List<StudyProgramSendDTO>> DeleteStudyProgramAsync(long id);

    Task<StudyProgramSendDTO> StudyProgramToStudyProgramSendDtoAsync(StudyProgram studyProgram);
}