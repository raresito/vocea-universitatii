using vocea_universitatii.Models.DTOs;

namespace vocea_universitatii.Services.StudyProgramService;

public interface IStudyProgramService
{
    Task<List<StudyProgramSendDTO>> GetAllStudyProgramsAsync();
    
    Task<StudyProgramSendDTO> GetSingleStudyProgramAsync(long id);
    
    Task<List<StudyProgramSendDTO>> AddStudyProgramAsync(StudyProgramCreateDTO studyProgram);
    
    Task<StudyProgramSendDTO> UpdateStudyProgramAsync(StudyProgramUpdateDTO request);
    
    Task<List<StudyProgramSendDTO>> DeleteStudyProgramAsync(long id);

    // StudyProgramSendDTO StudyProgramToStudyProgramSendDto(StudyProgram studyProgram);
}