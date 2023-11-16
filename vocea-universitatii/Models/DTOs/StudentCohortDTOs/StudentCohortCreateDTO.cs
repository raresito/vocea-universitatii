namespace VoceaUniversitatii.Models.DTOs.StudentCohortDTOs;

public class StudentCohortCreateDTO
{
    public string Name { get; set; }
    
    public int Size { get; set; }
    public long AcademicYearId { get; set; }
    
    public long StudyProgramId { get; set; }
    
    public long StudyYearId { get; set; }
    
    public long CohortTypeId { get; set; }
    
    public long? ParentStudentCohortId { get; set; }
}