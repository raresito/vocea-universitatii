namespace VoceaUniversitatiiDataModels.Models;

public class Question : BaseModel
{
    public long Id { get; set; }
    
    public string Title { get; set; }
    
    public Language Language { get; set; }
    
    public Boolean IsPrivate { get; set; }
    
    public ICollection<FormQuestionInclusion> FormQuestionInclusions { get; set; }
    
    public ICollection<Form> Forms { get; set; }
    
    // Migration - The position of the question in the form. This needs to be correlated with the answer's number.
    public int LegacyFormOrderNumber { get; set; }
    
    // Answers
    public QuestionType QuestionType {get; set;}
    public ICollection<QuestionOptions>? QuestionOptions { get; set; }
    
    public QuestionScale? QuestionScale { get; set; }
    
    public string? QuestionAnswer { get; set; }
}