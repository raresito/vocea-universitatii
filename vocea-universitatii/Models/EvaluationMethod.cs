namespace vocea_universitatii.Models;

public class EvaluationMethod : BaseModel
{
    public long Id { get; set; }
    
    public string Name { get; set; }

    public ICollection<Discipline> Disciplines { get; } = new List<Discipline>();
}