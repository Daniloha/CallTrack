using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallTrack.Data.entities.EntitiesConfiguration
{
    internal class ManagerConfiguration : IEntityTypeConfiguration<Managers>
    {
        public void Configure(EntityTypeBuilder<Managers> builder)
        {
            // Define o nome da tabela
            builder.
                ToTable("managers");

            // Define a chave primária e renomeia a coluna
            builder.
                HasKey(x => x.managerId);

            builder.
                Property(x => x.managerId).
                HasColumnName("manager_id").
                IsRequired();

            // Define o tamanho da coluna ManagerName, torna obrigatorio e renomeia a coluna
            builder.
                Property(x => x.managerName).
                HasColumnName("manager_name").
                HasMaxLength(100).
                IsRequired();

            // Define o relacionamento com a entidade Analysts
            builder.
                HasMany(x => x.analysts).
                WithOne(x => x.manager).
                HasForeignKey(x => x.analystId);

            // Define o relacionamento com a entidade Users
            builder.
                HasOne(x => x.user).
                WithOne(x => x.manager).
                HasForeignKey<Managers>(x => x.managerId);

            //Ignora as propriedades na serialização JSON
            //Equivalente a data annotation [Json Ignore]
            builder.
                Ignore(x => x.analysts);
            builder.
                Ignore(x => x.user);

        }
    }
}
