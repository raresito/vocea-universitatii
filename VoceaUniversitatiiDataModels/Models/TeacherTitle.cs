namespace VoceaUniversitatiiDataModels.Models;

public class TeacherTitle : BaseModel
{
    public long Id { get; set; }
    
    public string? Title { get; set; }

    public ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}