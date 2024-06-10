using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class Form
{
    public long Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<ActivityType> ActivityTypes { get; set; } = new List<ActivityType>();

    public virtual ICollection<EvaluationSession> EvaluationSessions { get; set; } = new List<EvaluationSession>();
}
