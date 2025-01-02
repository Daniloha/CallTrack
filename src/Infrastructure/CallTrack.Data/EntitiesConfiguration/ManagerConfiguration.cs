using CallTrack.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallTrack.Data.EntitiesConfiguration;

internal class ManagerConfiguration : IEntityTypeConfiguration<Managers>
{
    public void Configure(EntityTypeBuilder<Managers> builder)
    {
        // Define o nome da tabela
        builder.
            ToTable("managers");

        // Define a chave primária e renomeia a coluna
        builder.
            HasKey(x => x.ManagerId);

        builder.
            Property(x => x.ManagerId).
            HasColumnName("manager_id").
            IsRequired();

        builder.
            Property(x => x.UserId).
            HasColumnName("user_id").
            IsRequired();


        // Define o tamanho da coluna ManagerName, torna obrigatorio e renomeia a coluna
        builder.
            Property(x => x.ManagerName).
            HasColumnName("manager_name").
            HasMaxLength(100).
            IsRequired();

        // Define o relacionamento com a entidade Analysts
        builder
            .HasMany(x => x.Analysts)
            .WithOne(x => x.Manager)
            .HasForeignKey(x => x.ManagerId);

        // Define o relacionamento com a entidade Users
        builder
            .HasOne(x => x.User)
            .WithOne(x => x.Manager)
            .HasForeignKey<Managers>(x => x.UserId);


    }
}
