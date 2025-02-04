using CallTrack.Domain.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ManagerConfiguration : IEntityTypeConfiguration<Managers>
{
    public void Configure(EntityTypeBuilder<Managers> builder)
    {
        builder.ToTable("managers");

        builder.HasKey(x => x.ManagerId);

        builder.Property(x => x.ManagerId)
            .ValueGeneratedOnAdd()
            .HasColumnName("manager_id")
            .UseMySqlIdentityColumn()
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.ManagerName)
            .HasColumnName("manager_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<Managers>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
