using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatiiDataModels.Models;

namespace VoceaUniversitatiiDataModels.EntityTypeConfigurations;

public class LanguageEntityTypeConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder
            .Property(b => b.LanguageName)
            .IsRequired();
        builder
            .HasMany(l => l.StudyPrograms)
            .WithOne(sp => sp.Language)
            .HasForeignKey(sp => sp.LanguageId)
            .IsRequired();
        builder.HasData(
            new Language { Id = 1, LanguageName = "English"},
            new Language { Id = 2, LanguageName = "French"},
            new Language { Id = 3, LanguageName = "German"},
            new Language { Id = 4, LanguageName = "Romanian"}
        );
    }
}