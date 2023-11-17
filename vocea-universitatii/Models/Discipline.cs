namespace VoceaUniversitatii.Models;

public class Discipline : BaseModel
{
    public long Id { get; set; }

    public string FullName { get; set; }

    public int AbsoluteSemester { get; set; }

    public bool Optional { get; set; } = false;
    
    public bool Facultativ { get; set; }
    
    public long EvaluationMethodId { get; set; }
    
    public EvaluationMethod EvaluationMethod { get; set; }
    
    public long StudyProgramId { get; set; }

    public StudyProgram StudyProgram { get; set; }
    
    public long? ParentDisciplineId { get; set; }
    
    public Discipline? ParentDiscipline { get; set; }
    
    public ICollection<Discipline> ChildOptionslDisciplines { get; set; }
}