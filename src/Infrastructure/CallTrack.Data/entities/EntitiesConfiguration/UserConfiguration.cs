using Microsoft.EntityFrameworkCore;

namespace CallTrack.Data.entities.EntitiesConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Users> builder)
        {
            // Define o nome da tabela
            builder.
                ToTable("users");

            // Define a chave primária e renomeia a coluna
            builder.
                HasKey(x => x.userId);

            builder.
                Property(x => x.userId).
                HasColumnName("user_id").
                IsRequired();

            // Define o tamanho da coluna name, torna obrigatorio e renomeia a coluna
            builder.
                Property(x => x.email).
                HasColumnName("user_email").
                HasMaxLength(100).
                IsRequired().
                HasAnnotation("Relational:CheckConstraint", "email LIKE '%@%.%'");

            // Define o tamanho da coluna password, torna obrigatorio e renomeia a coluna
            builder.
                Property(x => x.password).
                HasColumnName("user_password").
                HasMaxLength(100).
                IsRequired();

            // Define o relacionamento com a entidade Managers
            builder.
                HasOne(x => x.manager).
                WithOne(x => x.user).
                HasForeignKey<Managers>(x => x.managerId);

            // Define o relacionamento com a entidade Analysts
            builder.
                HasOne(x => x.analyst).
                WithOne(x => x.user).
                HasForeignKey<Analyst>(x => x.analystId);

            //Ignora as propriedades na serialização JSON
            //Equivalente a data annotation [Json Ignore]
            builder.
                Ignore(x => x.analyst);
            builder.
                Ignore(x => x.manager);
        }
    }
}
