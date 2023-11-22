using VoceaUniversitatii.Models.DTOs.FacultyDTOs;

namespace VoceaUniversitatii.Services.FacultyService;

public interface IFacultyService
{
    Task<List<FacultySendDTO>> GetAllFaculties();
    
    Task<FacultySendDTO> GetSingleFaculty(long id);
    
    Task<FacultySendDTO> AddFaculty(FacultyCreateDTO faculty);
    
    Task<List<FacultySendDTO>> UpdateFaculty(FacultyUpdateDTO request);
    
    Task<List<FacultySendDTO>> DeleteFaculty(long id);
    
}