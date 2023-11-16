using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatii.Models;

namespace VoceaUniversitatii.Helpers.EntityTypeConfigurations;

public class TeacherTitleEntityTypeConfiguration : IEntityTypeConfiguration<TeacherTitle>
{
    public void Configure(EntityTypeBuilder<TeacherTitle> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder
            .HasMany(tt => tt.Teachers)
            .WithOne(t => t.Title)
            .HasForeignKey(t => t.TeacherTitleId)
            .IsRequired(false);
        builder
            .HasIndex(t=> t.Title)
            .IsUnique();
    }
}