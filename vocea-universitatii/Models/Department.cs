namespace VoceaUniversitatii.Models;

public class Department : BaseModel
{
    public long Id { get; set; }
    
    public String FullName { get; set; }
    
    public long FacultyId { get; set; }
    
    public Faculty Faculty { get; set; }
    
    public ICollection<TeacherDepartmentMembership> TeacherDepartmentMemberships { get; set; }
    
    public ICollection<Teacher> Teachers { get; set; }
}