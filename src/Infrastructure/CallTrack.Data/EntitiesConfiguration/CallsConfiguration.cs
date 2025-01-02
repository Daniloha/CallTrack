using CallTrack.Domain.entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallTrack.Data.EntitiesConfiguration
{
    public class CallsConfiguration : AbstractValidator<Calls>, IEntityTypeConfiguration<Calls>
    {
        public void Configure(EntityTypeBuilder<Calls> builder)
        {
            // Define o nome da tabela
            builder.ToTable("calls");

            // Define a chave primária e renomeia a coluna
            builder.HasKey(x => x.CallId);

            builder.Property(x => x.ReasonId).
                HasColumnName("reason_id").
                IsRequired();

            builder.Property(x => x.AnalystId).
                HasColumnName("analyst_id").
                IsRequired();


            builder.Property(x => x.CallId)
                   .HasColumnName("call_id")
                   .IsRequired();

            // Define o tamanho da coluna observation, torna obrigatório e renomeia a coluna
            builder.Property(x => x.Observation)
                   .HasMaxLength(500)
                   .HasColumnName("call_observation")
                   .IsRequired();

            // Define o relacionamento com a entidade Reasons
            builder.HasOne(x => x.Reasons)
                   .WithMany(x => x.Calls)
                   .HasForeignKey(x => x.ReasonId);

            // Define o relacionamento com a entidade Analyst
            builder.HasOne(x => x.Analyst)
                   .WithMany(x => x.Calls)
                   .HasForeignKey(x => x.AnalystId)
                   .OnDelete(DeleteBehavior.Restrict); // Define o comportamento na exclusão

            // Define a propriedade open_date como obrigatória
            builder.Property(x => x.OpenDate)
                   .HasColumnName("call_open_date")
                   .IsRequired();

            // Define a propriedade close_date como obrigatória
            builder.Property(x => x.CloseDate)
                   .HasColumnName("call_close_date")
                   .IsRequired();

            // Define a propriedade type como obrigatória, com valor padrão 0 e renomeia a coluna
            builder.Property(x => x.Type)
                   .HasColumnName("call_type")
                   .HasDefaultValue(0)
                   .IsRequired();

            // Define a propriedade code como obrigatória, com tamanho 12 e renomeia a coluna
            builder.Property(x => x.Code)
                   .HasColumnName("call_code")
                   .HasMaxLength(12)
                   .IsRequired();

            // Define a propriedade status como obrigatória, com valor padrão 0 e renomeia a coluna
            builder.Property(x => x.Status)
                   .HasColumnName("call_status")
                   .HasDefaultValue(0)
                   .IsRequired();

        }
    }
}
