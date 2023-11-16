namespace VoceaUniversitatii.Models.DTOs.FacultyDTOs;

public class FacultyCreateDTO
{
    public String FullName { get; set; }
    
    public String ShortName { get; set; }
    
    public static Faculty FacultyCreateDTOToFaculty(FacultyCreateDTO facultyCreateDto)
    {
        return new Faculty()
        {
            FullName = facultyCreateDto.FullName,
            ShortName = facultyCreateDto.ShortName
        };
    }
}