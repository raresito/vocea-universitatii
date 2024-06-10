using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class ActivityType
{
    public long Id { get; set; }

    public string? Title { get; set; }

    public long? FormId { get; set; }

    public virtual Form? Form { get; set; }
}
