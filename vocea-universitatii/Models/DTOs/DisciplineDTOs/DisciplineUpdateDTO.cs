namespace vocea_universitatii.Models.DTOs.DisciplineDTOs;

public class DisciplineUpdateDTO
{
    public long Id { get; set; }

    public string FullName { get; set; }

    public int AbsoluteSemester { get; set; }

    public bool Optional { get; set; }
    
    public long StudyProgramId { get; set; }
    
    public long EvaluationMethodId { get; set; }
}