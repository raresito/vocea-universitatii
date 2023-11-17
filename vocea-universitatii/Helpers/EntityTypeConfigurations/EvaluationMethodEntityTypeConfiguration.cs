using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatii.Models;

namespace VoceaUniversitatii.Helpers.EntityTypeConfigurations;

public class EvaluationMethodEntityTypeConfiguration: IEntityTypeConfiguration<EvaluationMethod>
{
    public void Configure(EntityTypeBuilder<EvaluationMethod> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder.Property(em => em.Name).IsRequired();
        builder
            .HasMany(em => em.Disciplines)
            .WithOne(d => d.EvaluationMethod)
            .HasForeignKey(d => d.EvaluationMethodId);
    }
}