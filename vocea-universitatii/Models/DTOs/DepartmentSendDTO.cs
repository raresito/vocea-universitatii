namespace vocea_universitatii.Models.DTOs;

public class DepartmentSendDTO
{
    public long Id { get; set; }
    
    public String FullName { get; set; }
    
    public FacultySendDTO Faculty { get; set; }
    
}