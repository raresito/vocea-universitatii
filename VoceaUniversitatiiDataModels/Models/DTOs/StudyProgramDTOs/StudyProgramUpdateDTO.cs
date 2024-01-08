namespace VoceaUniversitatiiDataModels.Models.DTOs.StudyProgramDTOs;

public class StudyProgramUpdateDTO
{
    public long Id { get; set; }
    
    public string FullName { get; set; }
    
    public long LanguageId { get; set; }
    
    public long FacultyId { get; set; }
}