using VoceaUniversitatii.Models.DTOs.StudyProgramDTOs;

namespace VoceaUniversitatii.Models.DTOs.StudentCohortDTOs;

public class StudentCohortSendDTO
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public int Size { get; set; }
    
    public AcademicYearSendDTO AcademicYear { get; set; }
    
    public StudyProgramSendDTO StudyProgram { get; set; }
    
    public StudyYearSendDTO StudyYear { get; set; }
    
    public CohortSendDTO CohortType { get; set; }
    
    public StudentCohortSendDTO? ParentStudentCohort { get; set; }
}