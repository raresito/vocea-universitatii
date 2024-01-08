using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatiiDataModels.Models;

namespace VoceaUniversitatiiDataModels.EntityTypeConfigurations;

public class DisciplineEntityTypeConfiguration : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder.Property(d => d.FullName).IsRequired();
        builder.Property(d => d.AbsoluteSemester).IsRequired();
        builder.Property(d => d.Optional).IsRequired();
        builder
            .HasOne<StudyProgram>(d => d.StudyProgram)
            .WithMany(sp => sp.Disciplines);
        builder
            .HasOne<Discipline>(d => d.ParentDiscipline)
            .WithMany(d => d.ChildOptionslDisciplines)
            .HasForeignKey(d => d.ParentDisciplineId)
            .IsRequired(false);
    }
}