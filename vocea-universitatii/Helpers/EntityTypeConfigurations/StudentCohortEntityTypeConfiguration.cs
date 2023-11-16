using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatii.Models;

namespace VoceaUniversitatii.Helpers.EntityTypeConfigurations;

public class StudentCohortEntityTypeConfiguration : IEntityTypeConfiguration<StudentCohort>
{
    public void Configure(EntityTypeBuilder<StudentCohort> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder
            .HasOne<AcademicYear>(sc => sc.AcademicYear)
            .WithMany(ay => ay.StudentCohorts)
            .IsRequired();
        builder
            .HasOne<StudyProgram>(sc => sc.StudyProgram)
            .WithMany(sp => sp.StudentCohorts)
            .IsRequired();
        
        builder
            .HasOne<Cohort>(sc => sc.CohortType)
            .WithMany(c => c.StudentCohorts)
            .IsRequired();
        builder
            .HasOne<StudyYear>(sc => sc.StudyYear)
            .WithMany(sy => sy.StudentCohorts)
            .IsRequired();

        builder
            .HasOne<StudentCohort>(sc => sc.ParentStudentCohort)
            .WithMany()
            .HasForeignKey(sc => sc.ParentStudentCohortId);
    }
}