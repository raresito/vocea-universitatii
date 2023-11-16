using VoceaUniversitatii.Models.DTOs.DepartmentDTOs;
using VoceaUniversitatii.Models.DTOs.TeacherDTOs.TeacherTitleDTOs;

namespace VoceaUniversitatii.Models.DTOs.TeacherDTOs;

public class TeacherSendDTO
{
    public long Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public long CNP { get; set; }
    
    public List<DepartmentOfTeacherSendDTO> Departments { get; set;  }
    
    public TeacherTitleSendDTO? TeacherTitle { get; set; }
}