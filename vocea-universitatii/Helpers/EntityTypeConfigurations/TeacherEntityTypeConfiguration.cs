using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatii.Models;

namespace VoceaUniversitatii.Helpers.EntityTypeConfigurations;

public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder
            .Property(b => b.CNP)
            .IsRequired();
    }
}