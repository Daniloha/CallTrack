/*
 * AnalystConfiguration.cs
 * -> Configuração da entidade Analyst para o banco de dados.
 */

using CallTrack.Domain.entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallTrack.Data.EntitiesConfiguration;

internal class AnalystConfiguration : AbstractValidator<Analyst>, IEntityTypeConfiguration<Analyst> 
{
    public void Configure(EntityTypeBuilder<Analyst> builder)
    {
        //Define o nome da tabela.
        builder.
            ToTable("analysts");

        //Define a chave primária e renomeia a coluna.
        builder.
            HasKey(x => x.AnalystId);

        builder.
            Property(x => x.UserId).
            HasColumnName("user_id").
            IsRequired();

        builder.
            Property(x => x.ManagerId).
            HasColumnName("manager_id").
            IsRequired();

        builder.
            Property(x => x.AnalystId).
            HasColumnName("analyst_id").
            IsRequired();

        //Define o tamanho da coluna analuystName, torna obrigatorio e renomeia a coluna.
        builder.
            Property(x => x.AnalystName).
            HasColumnName("analyst_name").
            HasMaxLength(100).
            IsRequired();
        //Renomeia a coluna statusAnalyst, torna obrigatorio.
        builder.
            Property(x => x.StatusAnalyst).
            HasColumnName("analyst_status").
            IsRequired();

        //Define o relacionamento com a entidade Calls
        builder.
            HasMany(x => x.Calls).
            WithOne(x => x.Analyst).
            HasForeignKey(x => x.CallId);

        //Define o valor padrao para a coluna statusAnalyst e torna obrigatorio.
        builder.
            Property(x => x.StatusAnalyst).
            HasDefaultValue(4).
            IsRequired();

        //Define o relacionamento com a entidade Users
        builder
            .HasOne(x => x.User)
            .WithOne(x => x.Analyst)
            .HasForeignKey<Analyst>(x => x.UserId)
            .HasConstraintName("user_id");


        //Define o relacionamento com a entidade Managers
        builder
            .HasOne(x => x.Manager)
            .WithMany(x => x.Analysts)
            .HasForeignKey(x => x.ManagerId)
            .HasConstraintName("FK_analysts_managers_ManagerId"); // Define explicitamente o nome da FK


        RuleFor(x => x.AnalystName).
            NotEmpty().
            WithMessage("O nome do analista é obrigatório.");

        RuleFor(x => x.StatusAnalyst).
            NotEmpty().
            WithMessage("O status do analista é obrigatório.");
            


    }
}
