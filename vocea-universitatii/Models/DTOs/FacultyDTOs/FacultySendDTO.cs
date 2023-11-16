namespace VoceaUniversitatii.Models.DTOs.FacultyDTOs;

public class FacultySendDTO
{
    public long Id { get; set; }
    
    public String FullName { get; set; }
    
    public String ShortName { get; set; }
    
    public static FacultySendDTO FacultyToFacultySendDTO(Faculty faculty)
    {
        return new FacultySendDTO()
        {
            Id = faculty.Id,
            FullName = faculty.FullName,
            ShortName = faculty.ShortName
        };
    }
}