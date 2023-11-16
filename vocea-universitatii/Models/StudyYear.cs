namespace VoceaUniversitatii.Models;

public class StudyYear
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<StudentCohort> StudentCohorts { get; set; }
}