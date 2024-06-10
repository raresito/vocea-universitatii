using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class EvaluationSession
{
    public long Id { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? Year { get; set; }

    public int? Semester { get; set; }

    public string? Status { get; set; }

    public bool? Terminal { get; set; }

    public long? FormId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? LastRefresh { get; set; }

    public int? FormSId { get; set; }

    public int? FormLId { get; set; }

    public int? FormAId { get; set; }

    public bool? Visibility { get; set; }

    public int? FormPId { get; set; }

    public virtual ICollection<EvalSessionActivity> EvalSessionActivities { get; set; } = new List<EvalSessionActivity>();

    public virtual ICollection<EvaluationSessionCohort> EvaluationSessionCohorts { get; set; } = new List<EvaluationSessionCohort>();

    public virtual Form? Form { get; set; }

    public virtual ICollection<IncognitoUser> IncognitoUsers { get; set; } = new List<IncognitoUser>();
}
