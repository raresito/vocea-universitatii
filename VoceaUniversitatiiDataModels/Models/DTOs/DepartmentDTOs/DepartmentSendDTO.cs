using VoceaUniversitatiiDataModels.Models.DTOs.FacultyDTOs;

namespace VoceaUniversitatiiDataModels.Models.DTOs.DepartmentDTOs;

public class DepartmentSendDTO
{
    public long Id { get; set; }
    
    public String FullName { get; set; }
    
    public FacultySendDTO Faculty { get; set; }
    
}