using vocea_universitatii.Models.DTOs.StudentCohortDTOs;

namespace vocea_universitatii.Services.StudentCohortService;

public interface IStudentCohortService
{
    Task<List<StudentCohortSendDTO>> GetAllStudentCohortsAsync();
    
    Task<StudentCohortSendDTO> GetSingleStudentCohortAsync(long id);
    
    Task<List<StudentCohortSendDTO>> AddStudentCohortAsync(StudentCohortCreateDTO StudentCohort);
    
    Task<StudentCohortSendDTO> UpdateStudentCohortAsync(StudentCohortUpdateDTO request);
    
    Task<List<StudentCohortSendDTO>> DeleteStudentCohortAsync(long id);
}