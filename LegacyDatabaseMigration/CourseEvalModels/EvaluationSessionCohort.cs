using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class EvaluationSessionCohort
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public bool? IsTerminal { get; set; }

    public int? StudentsNumber { get; set; }

    public int? OptionalsNumber { get; set; }

    public long? DepartmentId { get; set; }

    public long? EvaluationSessionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Language { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<EvalSessionActivity> EvalSessionActivities { get; set; } = new List<EvalSessionActivity>();

    public virtual EvaluationSession? EvaluationSession { get; set; }

    public virtual ICollection<IncognitoUser> IncognitoUsers { get; set; } = new List<IncognitoUser>();
}
