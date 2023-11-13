namespace vocea_universitatii.Models;

public class Faculty : BaseModel
{
    public long Id { get; set; }
    
    public String FullName { get; set; }
    
    public String ShortName { get; set; }
    
    public ICollection<Department> Departments { get; set; }
    
    public ICollection<StudyProgram> StudyPrograms { get; set; }
}