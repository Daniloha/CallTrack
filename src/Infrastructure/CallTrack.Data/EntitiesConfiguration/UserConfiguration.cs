using CallTrack.Domain.entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CallTrack.Data.EntitiesConfiguration;

public class UserConfiguration :AbstractValidator<Users>, IEntityTypeConfiguration<Users>
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
            UseMySqlIdentityColumn().
            IsRequired();

        builder.
            Property(x => x.AnalystId).
            HasColumnName("analyst_id");

        builder.
            Property(x => x.ManagerId).
            HasColumnName("manager_id");

        // Define o tamanho da coluna name, torna obrigatorio e renomeia a coluna
        builder.
            Property(x => x.Email).
            HasColumnName("user_email").
            HasMaxLength(100).
            IsRequired();

        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty()
            .WithMessage("Email inválido ou vazio.");

        // Define o tamanho da coluna password, torna obrigatorio e renomeia a coluna
        builder.
            Property(x => x.Password).
            HasColumnName("user_password").
            HasMaxLength(100).
            IsRequired();

        // Define o relacionamento com a entidade Managers
        builder
            .HasOne(x => x.Manager)
            .WithOne(x => x.User)
            .HasForeignKey<Managers>(x => x.UserId);

        // Define o relacionamento com a entidade Analysts
        builder
            .HasOne(x => x.Analyst)
            .WithOne(x => x.User) 
            .HasForeignKey<Analyst>(x => x.UserId);


    }
}
