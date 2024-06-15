namespace VoceaUniversitatiiDataModels.Models;

public class Form : BaseModel
{
    public long Id { get; set; }
    
    public string FormName { get; set; }
    
    public long LanguageId { get; set; }
    
    public Language Language { get; set; }
    
    public ICollection<FormQuestionInclusion> FormQuestionInclusions { get; set; }
    public ICollection<Question>? Questions { get; set; }
}