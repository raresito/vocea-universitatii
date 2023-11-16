namespace vocea_universitatii.Models;

public class User
{
    public int id { get; set; }

    public string FullName { get; set; }
    
    public string Email { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public DateTime DeletedAt { get; set; }
}