﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatiiDataModels.Models;

namespace VoceaUniversitatiiDataModels.EntityTypeConfigurations;

public class FacultyEntityTypeConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder
            .Property(b => b.FullName)
            .IsRequired();
        builder
            .Property(b => b.ShortName)
            .IsRequired();
        builder
            .HasMany<Department>(c => c.Departments)
            .WithOne(c => c.Faculty)
            .HasForeignKey(c => c.FacultyId)
            .IsRequired();
        builder
            .HasMany<StudyProgram>(s => s.StudyPrograms)
            .WithOne(c => c.Faculty)
            .HasForeignKey(c => c.FacultyId)
            .IsRequired();
    }
}