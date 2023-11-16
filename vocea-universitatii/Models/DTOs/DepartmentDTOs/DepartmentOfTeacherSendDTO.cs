using VoceaUniversitatii.Models.DTOs.FacultyDTOs;

namespace VoceaUniversitatii.Models.DTOs.DepartmentDTOs;

public class DepartmentOfTeacherSendDTO
{
    public long Id { get; set; }
    
    public String FullName { get; set; }
    
    public FacultySendDTO Faculty { get; set; }
    
    public bool BaseDepartment { get; set; }
}