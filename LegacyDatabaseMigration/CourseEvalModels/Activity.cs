using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class Activity
{
    public long Id { get; set; }

    public long? CourseId { get; set; }

    public long? CohortId { get; set; }

    public bool? IsOptional { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? TeacherId { get; set; }

    public int? Year { get; set; }

    public int? Semester { get; set; }

    public string? ActivityType { get; set; }

    public virtual Cohort? Cohort { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
