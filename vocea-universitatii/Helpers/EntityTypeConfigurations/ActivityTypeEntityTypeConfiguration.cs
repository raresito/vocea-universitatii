using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoceaUniversitatii.Models;

namespace VoceaUniversitatii.Helpers.EntityTypeConfigurations;

public class ActivityTypeEntityTypeConfiguration : IEntityTypeConfiguration<ActivityType>
{
    public void Configure(EntityTypeBuilder<ActivityType> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasKey(c => c.Id);
        builder
            .HasIndex(at => at.Name)
            .IsUnique();
        builder
            .Property(at => at.Name)
            .IsRequired();
        builder
            .HasMany<Activity>(at => at.Activities)
            .WithOne(a => a.ActivityType)
            .IsRequired();
    }
}