using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class ActiveIncognitoUser
{
    public long Id { get; set; }

    public DateTime? StartDate { get; set; }

    public string? IncognitoUserToken { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
