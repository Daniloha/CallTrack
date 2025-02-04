using CallTrack.Domain.entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class UserConfiguration : AbstractValidator<Users>, IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.UserId);

        builder.Property(x => x.UserId)
            .ValueGeneratedOnAdd()
            .HasColumnName("user_id")
            .UseMySqlIdentityColumn()
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("user_email")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasColumnName("user_password")
            .HasMaxLength(100)
            .IsRequired();

        // As chaves estrangeiras manager_id e analyst_id podem ser nulas inicialmente
        builder.Property(x => x.AnalystId)
            .HasColumnName("analyst_id")
            .IsRequired(false);

        builder.Property(x => x.ManagerId)
            .HasColumnName("manager_id")
            .IsRequired(false);

        // Define relacionamento com Manager (Um user pode ter um Manager)
        builder.HasOne(x => x.Manager)
            .WithMany()
            .HasForeignKey(x => x.ManagerId)
            .OnDelete(DeleteBehavior.SetNull);

        // Define relacionamento com Analyst (Um user pode ter um Analyst)
        builder.HasOne(x => x.Analyst)
            .WithMany()
            .HasForeignKey(x => x.AnalystId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
