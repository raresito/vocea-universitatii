namespace VoceaUniversitatiiDataModels.Models;

public class StudyProgram : BaseModel
{
    public long Id { get; set; }
    
    public string FullName { get; set; }
    
    public long LanguageId { get; set; }
    
    public Language Language { get; set; }
    
    public long FacultyId { get; set; }
    
    public Faculty Faculty { get; set; }
    
    public ICollection<AcademicYear> AcademicYears { get; set; }
    
    
    public ICollection<StudyProgramAcademicYearEnrollments> StudyProgramAcademicYearEnrollments { get; set; }
    
    public ICollection<StudentCohort> StudentCohorts { get; set; }
    
    public ICollection<Discipline> Disciplines { get; set; }
    
}