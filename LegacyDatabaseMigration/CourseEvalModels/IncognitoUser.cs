using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class IncognitoUser
{
    public long Id { get; set; }

    public string? Token { get; set; }

    public long? EvaluationSessionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? EvaluationSessionCohortId { get; set; }

    public virtual EvaluationSession? EvaluationSession { get; set; }

    public virtual EvaluationSessionCohort? EvaluationSessionCohort { get; set; }
}
