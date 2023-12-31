﻿namespace VoceaUniversitatiiDataModels.Models;

public class StudentCohort : BaseModel
{
    public long Id { get; set; }
    
    public string Name { get; set; }

    public int Size { get; set; } = 0;
    
    public long AcademicYearId { get; set; }
    
    public AcademicYear AcademicYear { get; set; }
    
    public long StudyProgramId { get; set; }
    
    public StudyProgram StudyProgram { get; set; }
    
    public long StudyYearId { get; set; }
    
    public StudyYear StudyYear { get; set; }
    
    
    public long CohortTypeId { get; set; }
    
    public Cohort CohortType { get; set; }
    
    public long? ParentStudentCohortId { get; set; }
    
    public StudentCohort? ParentStudentCohort { get; set; }
}