using System.Text.Json.Serialization;
using HttpClientSample;

namespace LegacyDatabaseMigration.CourseEvalModels.CourseEvalFormModels;

public class LegacyQuestionSection
{
    [JsonPropertyName("intrebare")]
    public List<QuestionOrLabel> Intrebare { get; set; }
    
    [JsonPropertyName("label")]
    public string Label { get; set; }
}