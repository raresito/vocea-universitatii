using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vocea_universitatii.Models;

namespace vocea_universitatii.Helpers;

public class EvaluationMethodEntityTypeConfiguration: IEntityTypeConfiguration<EvaluationMethod>
{
    public void Configure(EntityTypeBuilder<EvaluationMethod> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder
            .HasMany(em => em.Disciplines)
            .WithOne(d => d.EvaluationMethod)
            .HasForeignKey(d => d.EvaluationMethodId);
    }
}