namespace vocea_universitatii.Models;

public class Discipline
{
    public long Id { get; set; }

    public string FullName { get; set; }

    public int AbsoluteSemester { get; set; }

    public bool Optional { get; set; }
    
    public long StudyProgramId { get; set; }

    public StudyProgram StudyProgram { get; set; }
}