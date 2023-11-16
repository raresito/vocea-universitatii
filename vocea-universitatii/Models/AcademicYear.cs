namespace VoceaUniversitatii.Models;

public class AcademicYear
{
    public long Id { get; set; }
    
    public int StartYear { get; set; }
    
    public int EndYear { get; set; }
    
    public ICollection<StudyProgram> StudyPrograms { get; set; }
    public ICollection<StudentCohort> StudentCohorts { get; set; }
    
    public ICollection<StudyProgramAcademicYearEnrollments> StudyProgramAcademicYearEnrollments { get; set; }
}