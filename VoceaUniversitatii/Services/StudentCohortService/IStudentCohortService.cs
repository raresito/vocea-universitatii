using VoceaUniversitatiiDataModels.Models.DTOs.StudentCohortDTOs;

namespace VoceaUniversitatii.Services.StudentCohortService;

public interface IStudentCohortService
{
    Task<List<StudentCohortSendDTO>> GetAllStudentCohortsAsync();
    
    Task<StudentCohortSendDTO> GetSingleStudentCohortAsync(long id);
    
    Task<List<StudentCohortSendDTO>> AddStudentCohortAsync(StudentCohortCreateDTO StudentCohort);
    
    Task<StudentCohortSendDTO> UpdateStudentCohortAsync(StudentCohortUpdateDTO request);
    
    Task<List<StudentCohortSendDTO>> DeleteStudentCohortAsync(long id);
}