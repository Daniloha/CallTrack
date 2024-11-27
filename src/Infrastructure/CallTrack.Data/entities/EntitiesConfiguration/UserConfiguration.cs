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
                HasKey(x => x.UserId);

            builder.
                Property(x => x.UserId).
                HasColumnName("user_id").
                IsRequired();

            // Define o tamanho da coluna name, torna obrigatorio e renomeia a coluna
            builder.
                Property(x => x.email).
                HasColumnName("user_email").
                HasMaxLength(100).
                IsRequired();

            // Define o tamanho da coluna password, torna obrigatorio e renomeia a coluna
            builder.
                Property(x => x.password).
                HasColumnName("user_password").
                HasMaxLength(100).
                IsRequired();

            // Define o relacionamento com a entidade Managers
            builder.
                HasMany(x => x.managers);

            // Define o relacionamento com a entidade Analysts
            builder.
                HasMany(x => x.analysts);
        }
    }
}
