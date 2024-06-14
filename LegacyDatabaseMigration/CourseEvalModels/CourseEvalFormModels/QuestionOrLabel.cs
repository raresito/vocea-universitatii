using System.Text.Json.Serialization;

namespace LegacyDatabaseMigration.CourseEvalModels.CourseEvalFormModels;

public class QuestionOrLabel
{
    [JsonPropertyName("enunt")]
    public string Enunt { get; set; }
    
    [JsonPropertyName("rasp")]
    public string Rasp { get; set; }
    
    [JsonPropertyName("label")]
    public string Label { get; set; }
}