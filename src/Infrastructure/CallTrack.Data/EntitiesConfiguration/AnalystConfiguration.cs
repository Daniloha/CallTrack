using CallTrack.Domain.entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class AnalystConfiguration : AbstractValidator<Analyst>, IEntityTypeConfiguration<Analyst>
{
    public void Configure(EntityTypeBuilder<Analyst> builder)
    {
        builder.ToTable("analysts");

        builder.HasKey(x => x.AnalystId);

        builder.Property(x => x.AnalystId)
            .ValueGeneratedOnAdd()
            .HasColumnName("analyst_id")
            .UseMySqlIdentityColumn()
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.ManagerId)
            .HasColumnName("manager_id")
            .IsRequired();

        builder.Property(x => x.AnalystName)
            .HasColumnName("analyst_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.StatusAnalyst)
            .HasColumnName("analyst_status")
            .HasDefaultValue(4)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<Analyst>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Manager)
            .WithMany(x => x.Analysts)
            .HasForeignKey(x => x.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
