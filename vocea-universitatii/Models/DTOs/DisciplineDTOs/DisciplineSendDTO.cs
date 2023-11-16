using vocea_universitatii.Models.DTOs.DisciplineDTOs.EvaluationMethodDTOs;

namespace vocea_universitatii.Models.DTOs.DisciplineDTOs;

public class DisciplineSendDTO
{
    public long Id { get; set; }

    public string FullName { get; set; }

    public int AbsoluteSemester { get; set; }

    public bool Optional { get; set; }
    
    public EvaluationMethodSendDTO EvaluationMethod { get; set; }
    
    public StudyProgramSendDTO StudyProgram { get; set; }
}