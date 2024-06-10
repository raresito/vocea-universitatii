namespace VoceaUniversitatiiDataModels.Models;

public class Question
{
    public long Id { get; set; }
    
    public string Title { get; set; }
    
    public Language Language { get; set; }
    
    public Boolean IsPrivate { get; set; }
    
    public QuestionType QuestionType {get; set;}
    
    // The position of the question in the form. This needs to be correlated with the answer's number.
    public int LegacyFormOrderNumber { get; set; }
    
    public ICollection<QuestionOptions>? QuestionOptions { get; set; }
    
    public QuestionScale? QuestionScale { get; set; }
    
    public string? QuestionAnswer { get; set; }
}