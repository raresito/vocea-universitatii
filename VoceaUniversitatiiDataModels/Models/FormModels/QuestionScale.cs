namespace VoceaUniversitatiiDataModels.Models;

public class QuestionScale : BaseModel
{
    public long Id { get; set; }
    
    public long QuestionId { get; set; }
    public Question Question { get; set; }
    
    public int MinValue { get; set; }
    
    public int MaxValue { get; set; }
}