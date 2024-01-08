using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatiiDataModels.Models;

namespace VoceaUniversitatiiDataModels.EntityTypeConfigurations;

public class AcademicYearEntityTypeConfiguration : IEntityTypeConfiguration<AcademicYear>
{
    public void Configure(EntityTypeBuilder<AcademicYear> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder
            .Property(b => b.StartYear)
            .IsRequired();
        builder
            .Property(b => b.EndYear)
            .IsRequired();
        builder.HasData(
            new AcademicYear { Id = 1, StartYear = 2022, EndYear = 2023 },
            new AcademicYear { Id = 2, StartYear = 2023, EndYear = 2024 },
            new AcademicYear { Id = 3, StartYear = 2024, EndYear = 2025 }
            );
    }
}