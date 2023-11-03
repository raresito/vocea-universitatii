using vocea_universitatii.Controllers;

namespace vocea_universitatii.Models;

public class Department : BaseModel
{
    public long Id { get; set; }
    
    public String FullName { get; set; }
    
    public long FacultyId { get; set; }
    
    public Faculty Faculty { get; set; }
}