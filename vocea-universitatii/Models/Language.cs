namespace vocea_universitatii.Models;

public class Language
{
    public long Id { get; set; }
    
    public string LanguageName { get; set; }
    
    public ICollection<StudyProgram> StudyPrograms { get; } = new List<StudyProgram>();
}