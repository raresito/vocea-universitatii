using System.Text.Json.Serialization;

namespace LegacyDatabaseMigration.CourseEvalModels.CourseEvalFormModels;

public class LegacyQuestionSection
{
    [JsonPropertyName("intrebare")]
    public List<QuestionOrLabel> Intrebare { get; set; }
    
    [JsonPropertyName("label")]
    public string Label { get; set; }
}