namespace vocea_universitatii.Models.DTOs;

public class TeacherCreateDTO
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public long CNP { get; set; }
    
    public long BaseDepartmentId { get; set; }
    
    public long TeacherTitleId { get; set; }
}