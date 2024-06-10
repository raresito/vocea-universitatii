using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class Cohort
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public bool? IsTerminal { get; set; }

    public int? StudentsNumber { get; set; }

    public int? OptionalsNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DepartmentId { get; set; }

    public int? Year { get; set; }

    public string? Language { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual Department? Department { get; set; }
}
