using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class CompletedEvaluation
{
    public long Id { get; set; }

    public string? IncognitoToken { get; set; }

    public string? Content { get; set; }

    public int? Time { get; set; }

    public DateTime? Date { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? EvalSessionActivityId { get; set; }

    public virtual EvalSessionActivity? EvalSessionActivity { get; set; }
}
