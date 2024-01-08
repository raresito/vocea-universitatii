namespace VoceaUniversitatiiDataModels.Models;

public class Cohort
{
    public long Id { get; set; }
    
    public string CohortName { get; set; }
    
    public ICollection<StudentCohort> StudentCohorts { get; set; }
}