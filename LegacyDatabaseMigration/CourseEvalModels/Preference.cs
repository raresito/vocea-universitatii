using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class Preference
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Value { get; set; }
}
