namespace vocea_universitatii.Models.DTOs;

public class TeacherSendDTO
{
    public long Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public long CNP { get; set; }
    
    public List<DepartmentOfTeacherSendDTO> Departments { get; set;  }
}