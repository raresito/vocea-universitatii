using System;
using System.Collections.Generic;

namespace LegacyDatabaseMigration.CourseEvalModels;

public partial class User
{
    public long Uid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Status { get; set; }

    public string? Email { get; set; }

    public string? IsStudent { get; set; }

    public string? IsTeacher { get; set; }

    public string? IsManagement { get; set; }

    public string? IsAdmin { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Token { get; set; }

    public string? PasswordDigest { get; set; }
}
