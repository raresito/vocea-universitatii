namespace VoceaUniversitatii.Models;

public class StudyProgramAcademicYearEnrollments
{
    public long AcademicYearId { get; set; }
    
    public AcademicYear AcademicYear { get; set; }
    
    public long StudyProgramId { get; set; }
    
    public StudyProgram StudyProgram { get; set;  }
}