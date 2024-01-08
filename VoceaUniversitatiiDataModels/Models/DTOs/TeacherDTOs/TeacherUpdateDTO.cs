namespace VoceaUniversitatiiDataModels.Models.DTOs.TeacherDTOs;

public class TeacherUpdateDTO
{
    public long Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public long CNP { get; set; }
    
    public long BaseDepartmentId { get; set; }
    
    public long TeacherTitleId { get; set; }
}