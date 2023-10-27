namespace vocea_universitatii.Services.FacultyService;

public interface IFacultyService
{
    Task<List<Faculty>> GetAllFaculties();
    
    Task<Faculty> GetSingleFaculty(int id);
    
    Task<List<Faculty>> AddFaculty(Faculty faculty);
    
    Task<List<Faculty>> UpdateFaculty(int id, Faculty request);
    
    Task<List<Faculty>> DeleteFaculty(int id);
    
}