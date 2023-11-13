namespace vocea_universitatii.Models.DTOs;

public class StudyProgramCreateDTO
{
    public string FullName { get; set; }
    
    public long LanguageId { get; set; }
    
    public long FacultyId { get; set; }
}