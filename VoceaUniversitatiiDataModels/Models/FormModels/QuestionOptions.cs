namespace VoceaUniversitatiiDataModels.Models;

public class QuestionOptions
{
    public long Id { get; set; }
    
    public Question Question { get; set; }
    
    public string OptionText { get; set; }
}