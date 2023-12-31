﻿namespace VoceaUniversitatiiDataModels.Models;

public class Teacher : BaseModel
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public long? TeacherTitleId { get; set; }

    public TeacherTitle? Title { get; set; }
    
    public ICollection<TeacherDepartmentMembership> TeacherDepartmentMemberships { get; set; }
    
    public ICollection<Department> Departments { get; set; }
}