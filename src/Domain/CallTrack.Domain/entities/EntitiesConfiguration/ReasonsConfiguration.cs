using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallTrack.Domain.entities.EntitiesConfiguration;

internal class ReasonsConfiguration : IEntityTypeConfiguration<Reasons>
{
    public void Configure(EntityTypeBuilder<Reasons> builder)
    {
        // Define o nome da tabela
        builder.
            ToTable("reasons");

        // Define a chave primária e renomeia a coluna
        builder.
            HasKey(x => x.reasonId).
            HasName("reason_id");

        builder.
            Property(x => x.reasonId).
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
            HasOne(x => x.call).
            WithMany(x => x.reasons).
            HasForeignKey(x => x.reasonId);

        //Ignora as propriedades na serialização JSON
        //Equivalente a data annotation [Json Ignore]
        builder.
            Ignore(x => x.call);

    }
}
