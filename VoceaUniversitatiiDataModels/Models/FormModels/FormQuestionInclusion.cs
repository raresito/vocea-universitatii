namespace VoceaUniversitatiiDataModels.Models;

public class FormQuestionInclusion
{
    public long FormId { get; set; }

    public Form Form { get; set; }
    
    public long QuestionId { get; set; }
    
    public Question Question { get; set; }
}