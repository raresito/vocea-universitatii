﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatiiDataModels.Models;

namespace VoceaUniversitatiiDataModels.EntityTypeConfigurations;

public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder
            .Property(d => d.FacultyId)
            .IsRequired();
        builder
            .Property(b => b.FullName)
            .IsRequired();
        builder
            .HasMany<Teacher>(c => c.Teachers)
            .WithMany(c => c.Departments)
            .UsingEntity<TeacherDepartmentMembership>();
    }
}