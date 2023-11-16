using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatii.Models;

namespace VoceaUniversitatii.Helpers.EntityTypeConfigurations;

public class StudyProgramEntityTypeConfiguration : IEntityTypeConfiguration<StudyProgram>
{
    public void Configure(EntityTypeBuilder<StudyProgram> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder
            .HasMany<AcademicYear>(sp => sp.AcademicYears)
            .WithMany(ay => ay.StudyPrograms)
            .UsingEntity<StudyProgramAcademicYearEnrollments>();
    }
}