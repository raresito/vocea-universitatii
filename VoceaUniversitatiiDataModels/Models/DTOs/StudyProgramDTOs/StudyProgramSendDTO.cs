﻿using VoceaUniversitatiiDataModels.Models.DTOs.FacultyDTOs;

namespace VoceaUniversitatiiDataModels.Models.DTOs.StudyProgramDTOs;

public class StudyProgramSendDTO
{
    public long Id { get; set; }
    
    public string FullName { get; set; }
    
    public LanguageSendDTO Language { get; set; }
    
    public long FacultyId { get; set; }
    
    public FacultySendDTO Faculty { get; set; }
}