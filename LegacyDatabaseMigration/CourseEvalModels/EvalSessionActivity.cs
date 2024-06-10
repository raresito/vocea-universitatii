using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class EvalSessionActivity
{
    public long Id { get; set; }

    public long? CourseId { get; set; }

    public long? EvaluationSessionCohortId { get; set; }

    public bool? IsOptional { get; set; }

    public long? TeacherId { get; set; }

    public int? Year { get; set; }

    public int? Semester { get; set; }

    public string? ActivityType { get; set; }

    public long? EvaluationSessionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<CompletedEvaluation> CompletedEvaluations { get; set; } = new List<CompletedEvaluation>();

    public virtual Course? Course { get; set; }

    public virtual EvaluationSession? EvaluationSession { get; set; }

    public virtual EvaluationSessionCohort? EvaluationSessionCohort { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
