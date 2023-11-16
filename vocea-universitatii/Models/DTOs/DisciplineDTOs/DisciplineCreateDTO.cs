namespace VoceaUniversitatii.Models.DTOs.DisciplineDTOs;

public class DisciplineCreateDTO
{
    public string FullName { get; set; }

    public int AbsoluteSemester { get; set; }

    public bool Optional { get; set; }
    
    public long StudyProgramId { get; set; }
    
    public long EvaluationMethodId { get; set; }
}