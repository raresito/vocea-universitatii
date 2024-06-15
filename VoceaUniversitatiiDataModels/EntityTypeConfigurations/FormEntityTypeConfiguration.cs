using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatiiDataModels.Models;

namespace VoceaUniversitatiiDataModels.EntityTypeConfigurations;

public class FormEntityTypeConfiguration : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder
            .Property(b => b.LanguageId)
            .IsRequired();
        builder
            .HasMany(l => l.Questions)
            .WithMany(q => q.Forms)
            .UsingEntity<FormQuestionInclusion>();
    }
}