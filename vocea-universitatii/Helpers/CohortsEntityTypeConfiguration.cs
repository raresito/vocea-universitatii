using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vocea_universitatii.Models;

namespace vocea_universitatii.Helpers;

public class CohortsEntityTypeConfiguration : IEntityTypeConfiguration<Cohort>
{
    public void Configure(EntityTypeBuilder<Cohort> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        
        builder.HasData(
            new Cohort { Id = 1, CohortName = "Subgrupa" },
            new Cohort { Id = 2, CohortName = "Grupa" },
            new Cohort { Id = 3, CohortName = "Serie" },
            new Cohort { Id = 4, CohortName = "An" }
        );
    }
}