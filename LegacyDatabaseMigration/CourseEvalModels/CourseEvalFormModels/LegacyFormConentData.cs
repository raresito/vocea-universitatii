using System.Text.Json.Serialization;

namespace LegacyDatabaseMigration.CourseEvalModels.CourseEvalFormModels;

public class LegacyFormConentData
{
    [JsonPropertyName("chestionar")]
    public List<List<LegacyQuestionSection>> Chestionar { get; set; }
}