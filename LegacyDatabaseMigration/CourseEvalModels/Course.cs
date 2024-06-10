using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class Course
{
    public long Id { get; set; }

    public string? Title { get; set; }

    public string? Uid { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DepartmentId { get; set; }

    public string? Year { get; set; }

    public string? Specialization { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<EvalSessionActivity> EvalSessionActivities { get; set; } = new List<EvalSessionActivity>();
}
