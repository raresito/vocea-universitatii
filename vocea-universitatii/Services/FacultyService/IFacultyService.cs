using vocea_universitatii.Models;
using vocea_universitatii.Models.DTOs;

namespace vocea_universitatii.Services.FacultyService;

public interface IFacultyService
{
    Task<List<FacultySendDTO>> GetAllFaculties();
    
    Task<FacultySendDTO> GetSingleFaculty(long id);
    
    Task<List<FacultySendDTO>> AddFaculty(FacultyCreateDTO faculty);
    
    Task<List<FacultySendDTO>> UpdateFaculty(FacultyUpdateDTO request);
    
    Task<List<FacultySendDTO>> DeleteFaculty(long id);
    
}