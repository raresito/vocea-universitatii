namespace VoceaUniversitatiiDataModels.Models;

public class EvaluationSession
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public AcademicYear AcademicYear { get; set; }
}