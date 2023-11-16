using VoceaUniversitatii.Models.DTOs.FacultyDTOs;

namespace VoceaUniversitatii.Models.DTOs.DepartmentDTOs;

public class DepartmentSendDTO
{
    public long Id { get; set; }
    
    public String FullName { get; set; }
    
    public FacultySendDTO Faculty { get; set; }
    
}