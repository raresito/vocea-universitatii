namespace vocea_universitatii.Models.DTOs.StudentCohortDTOs;

public class StudentCohortUpdateDTO
{
    public long Id { get; set; }
    
    public int Size { get; set; }
    
    public string Name { get; set; }
    
    public long AcademicYearId { get; set; }
    
    public long StudyProgramId { get; set; }
    
    public long StudyYearId { get; set; }
    
    public long CohortTypeId { get; set; }
    
    public long? ParentStudentCohortId { get; set; }
}