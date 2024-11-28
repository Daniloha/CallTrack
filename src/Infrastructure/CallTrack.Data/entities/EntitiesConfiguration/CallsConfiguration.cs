using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallTrack.Data.entities.EntitiesConfiguration
{
    internal class CallsConfiguration : IEntityTypeConfiguration<Calls>
    {
        public void Configure(EntityTypeBuilder<Calls> builder)
        {
            // Define o nome da tabela
            builder.
                ToTable("calls");

            // Define a chave primária e renomeia a coluna
            builder.
                HasKey(x => x.callId);

            builder.
                Property(x => x.callId).
                HasColumnName("call_id").
                IsRequired();

            // Define o tamanho da coluna observation, torna obrigatório e renomeia a coluna
            builder.Property(x => x.observation)
                   .HasMaxLength(500)
                   .HasColumnName("call_observation")
                   .IsRequired();

            // Define o relacionamento com a entidade Reasons
            builder.HasMany(x => x.reasons)
                   .WithOne(x => x.call)
                   .HasForeignKey(x => x.reasonId);

            //Define a propriedade open_date como obrigatório
            builder.
                Property(x => x.openDate).
                HasColumnName("call_open_date").
                IsRequired();

            //Define a propriedade close_date como obrigatório
            builder.
                Property(x => x.closeDate).
                HasColumnName("call_close_date").
                IsRequired();

            //Define a propriedade type como obrigatório, com valor padrão 0 e renomeia a coluna
            builder.
                Property(x => x.type).
                HasColumnName("call_type").
                HasDefaultValue(0).
                IsRequired();
            
            //Define a propriedade code como obrigatório, com tamanho 12 e renomeia a coluna
            builder.
                Property(x => x.code).
                HasColumnName("call_code").
                HasMaxLength(12).
                IsRequired();

            //Define a propriedade status como obrigatório, com valor padrão 0 e renomeia a coluna
            builder.
                Property(x => x.status).
                HasColumnName("call_status").
                HasDefaultValue(0).
                IsRequired();

            //Define o relacionamento com a entidade Analyst
            builder.
                HasOne(x => x.analyst).
                WithMany(x => x.calls).
                HasForeignKey(x => x.callId);

            //Ignora as propriedades na serialização JSON
            //Equivalente a data annotation [Json Ignore]
            builder.
                Ignore(x => x.analyst);
            builder.
                Ignore(x => x.reasons);
        }
    }
}
