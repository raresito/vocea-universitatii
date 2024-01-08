using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatiiDataModels.Models;

namespace VoceaUniversitatiiDataModels.EntityTypeConfigurations;

public class StudyProgramEntityTypeConfiguration : IEntityTypeConfiguration<StudyProgram>
{
    public void Configure(EntityTypeBuilder<StudyProgram> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder.Property(sp => sp.FacultyId).IsRequired();
        builder.Property(sp => sp.FullName).IsRequired();
        builder.Property(sp => sp.LanguageId).IsRequired();
        builder
            .HasMany<AcademicYear>(sp => sp.AcademicYears)
            .WithMany(ay => ay.StudyPrograms)
            .UsingEntity<StudyProgramAcademicYearEnrollments>();
    }
}