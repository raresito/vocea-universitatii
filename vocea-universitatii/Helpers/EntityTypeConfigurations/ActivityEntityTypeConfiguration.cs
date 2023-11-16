﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatii.Models;

namespace VoceaUniversitatii.Helpers.EntityTypeConfigurations;

public class ActivityEntityTypeConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder
            .Property(b => b.Id).ValueGeneratedOnAdd();
        builder
            .HasIndex(a => a.Id)
            .IsUnique();
        builder
            .HasKey(a => new { a.DisciplineId, a.ActivityTypeId, a.TeacherId });
    }
}