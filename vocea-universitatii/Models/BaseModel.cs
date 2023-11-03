namespace vocea_universitatii;

public class BaseModel
{
    public User? CreatedBy { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public User? UpdatedBy { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public User? DeletedBy { get; set; }
    
    public DateTime DeletedAt { get; set; }
}