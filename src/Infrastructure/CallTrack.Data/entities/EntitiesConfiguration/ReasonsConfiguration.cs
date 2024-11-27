using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallTrack.Data.entities.EntitiesConfiguration
{
    internal class ReasonsConfiguration : IEntityTypeConfiguration<Reasons>
    {
        public void Configure(EntityTypeBuilder<Reasons> builder)
        {
            // Define o nome da tabela
            builder.
                ToTable("reasons");

            // Define a chave primária e renomeia a coluna
            builder.
                HasKey(x => x.ReasonId).
                HasName("reason_id");

            builder.
                Property(x => x.ReasonId).
                HasColumnName("reason_id").
                IsRequired();

            // Define o tamanho da coluna description, torna obrigatorio e renomeia a coluna
            builder.
                Property(x => x.description).
                HasColumnName("reason_description").
                HasMaxLength(500).
                IsRequired();

            // Define o relacionamento com a entidade Calls
            builder.
                HasOne(x => x.calls).
                WithMany(x => x.reasons).
                HasForeignKey(x => x.ReasonId);
        }
    }
}
