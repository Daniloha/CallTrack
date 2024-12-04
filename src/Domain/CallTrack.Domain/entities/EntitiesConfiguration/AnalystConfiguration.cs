/*
 * AnalystConfiguration.cs
 * -> Configuração da entidade Analyst para o banco de dados.
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallTrack.Domain.entities.EntitiesConfiguration;

internal class AnalystConfiguration : IEntityTypeConfiguration<Analyst>
{
    public void Configure(EntityTypeBuilder<Analyst> builder)
    {
        //Define o nome da tabela.
        builder.
            ToTable("analysts");

        //Define a chave primária e renomeia a coluna.
        builder.
            HasKey(x => x.analystId);

        builder.
            Property(x => x.analystId).
            HasColumnName("analyst_id").
            IsRequired();

        //Define o tamanho da coluna analuystName, torna obrigatorio e renomeia a coluna.
        builder.
            Property(x => x.analystName).
            HasColumnName("analyst_name").
            HasMaxLength(100).
            IsRequired();
        //Renomeia a coluna statusAnalyst, torna obrigatorio.
        builder.
            Property(x => x.statusAnalyst).
            HasColumnName("analyst_status").
            IsRequired();

        //Define o relacionamento com a entidade Calls
        builder.
            HasMany(x => x.calls).
            WithOne(x => x.analyst).
            HasForeignKey(x => x.callId);

        //Define o valor padrao para a coluna statusAnalyst e torna obrigatorio.
        builder.
            Property(x => x.statusAnalyst).
            HasDefaultValue(4).
            IsRequired();

        //Define o relacionamento com a entidade Users
        builder.
            HasOne(x => x.user).
            WithOne(x => x.analyst).
            HasForeignKey<Analyst>(x => x.analystId);

        //Define o relacionamento com a entidade Managers
        builder.
            HasOne(x => x.manager).
            WithMany(x => x.analysts).
            HasForeignKey(x => x.analystId);

        //Ignora as propriedades na serialização JSON
        //Equivalente a data annotation [Json Ignore]
        builder.
            Ignore(x => x.calls);
        builder.
            Ignore(x => x.manager);
        builder.
            Ignore(x => x.user);
            


    }
}
