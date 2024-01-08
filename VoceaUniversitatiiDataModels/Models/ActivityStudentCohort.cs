namespace VoceaUniversitatiiDataModels.Models;

public class ActivityStudentCohort : BaseModel
{
    public long ActivityId { get; set; }

    public Activity Activity { get; set; }
    
    public long StudentCohortId { get; set; }
    
    public StudentCohort StudentCohort { get; set; }
}

