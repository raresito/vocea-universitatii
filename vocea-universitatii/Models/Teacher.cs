namespace vocea_universitatii.Models;

public class Teacher : BaseModel
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public long CNP { get; set; }
    
    public ICollection<TeacherDepartmentMembership> TeacherDepartmentMemberships { get; set; }
    
    public ICollection<Department> Departments { get; set; }
}