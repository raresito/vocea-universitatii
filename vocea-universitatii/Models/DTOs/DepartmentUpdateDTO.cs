﻿namespace vocea_universitatii.Models.DTOs;

public class DepartmentUpdateDTO
{
    public long Id { get; set; }
    public String FullName { get; set; }
    
    public long FacultyId { get; set; }
}