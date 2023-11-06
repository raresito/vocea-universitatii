namespace vocea_universitatii.Models;

public class TeacherDepartmentMembership : BaseModel
{
    public long TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public long DepartmentId { get; set; }
    public Department Department { get; set; }

    public bool BaseDepartment { get; set; } = true;
    
    
    
    
}