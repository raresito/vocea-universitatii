namespace vocea_universitatii.Models.DTOs;

public class StudyProgramUpdateDTO
{
    public long Id { get; set; }
    
    public string FullName { get; set; }
    
    public long LanguageId { get; set; }
    
    public long FacultyId { get; set; }
}