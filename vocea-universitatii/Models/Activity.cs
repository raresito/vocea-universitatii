namespace VoceaUniversitatii.Models;

public class Activity : BaseModel
{
    public long Id { get; set; }
    
    public long TeacherId { get; set; }
    
    public Teacher Teacher { get; set; }
    
    public long DisciplineId { get; set; }
    
    public Discipline Discipline { get; set; }
    
    public long ActivityTypeId { get; set; }
    
    public ActivityType ActivityType { get; set; }
}