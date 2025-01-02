using CallTrack.Data.entities;
using CallTrack.Domain.entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CallTrack.Data;

public class CallTrackContext : DbContext
{
    public CallTrackContext(DbContextOptions<CallTrackContext> options)
        : base(options) { }

        public DbSet<Calls> Calls { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Analyst> Analysts { get; set; }
        public DbSet<Managers> Managers { get; set; }
        public DbSet<Reasons> Reasons { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(CallTrackContext)
        .Assembly);

        builder.Entity<Reasons>().HasData(
                new Reasons { ReasonId = 1, Description = "PIX" },
                new Reasons { ReasonId = 2, Description = "Saldo Bloqueado" },
                new Reasons { ReasonId = 3, Description = "Fila Errada" },
                new Reasons { ReasonId = 4, Description = "Duplicado" },
                new Reasons { ReasonId = 5, Description = "Erro de acesso ao app" },
                new Reasons { ReasonId = 6, Description = "Orientação" },
                new Reasons { ReasonId = 7, Description = "Erro Geral / Intermitência" },
                new Reasons { ReasonId = 8, Description = "Cancelamento de Cartão" },
                new Reasons { ReasonId = 9, Description = "Cancelamento Conta" },
                new Reasons { ReasonId = 10, Description = "Alteração Cadastral" },
                new Reasons { ReasonId = 11, Description = "Alteração de Type" },
                new Reasons { ReasonId = 12, Description = "Conta Topázio" },
                new Reasons { ReasonId = 13, Description = "Desassociação" },
                new Reasons { ReasonId = 14, Description = "Redefinição de Senha" },
                new Reasons { ReasonId = 15, Description = "SMS" },
                new Reasons { ReasonId = 16, Description = "Token de Ativação" },
                new Reasons { ReasonId = 17, Description = "Chip APAG" },
                new Reasons { ReasonId = 18, Description = "Maquininha" },
                new Reasons { ReasonId = 19, Description = "QR Code" },
                new Reasons { ReasonId = 20, Description = "Saque Tecban" },
                new Reasons { ReasonId = 21, Description = "Transferencia" },
                new Reasons { ReasonId = 22, Description = "Devolução da Maquininha" },
                new Reasons { ReasonId = 23, Description = "Conta congelada" },
                new Reasons { ReasonId = 24, Description = "Conta encerrada" },
                new Reasons { ReasonId = 25, Description = "Conta Bloqueada" },
                new Reasons { ReasonId = 26, Description = "Chamado Teste" },
                new Reasons { ReasonId = 27, Description = "Credito em Conta" },
                new Reasons { ReasonId = 28, Description = "Não aparece conta/cartao" },
                new Reasons { ReasonId = 29, Description = "Parâmetros Inválidos APP" },
                new Reasons { ReasonId = 30, Description = "Parâmetros Inválidos Maquininha" },
                new Reasons { ReasonId = 31, Description = "Relatorio de vendas app" },
                new Reasons { ReasonId = 32, Description = "Transação APAG" },
                new Reasons { ReasonId = 33, Description = "Reset de Chip" },
                new Reasons { ReasonId = 34, Description = "Cancelamento Transação" },
                new Reasons { ReasonId = 35, Description = "Estorno Adesão Apag" },
                new Reasons { ReasonId = 36, Description = "Efeito de Contrato" },
                new Reasons { ReasonId = 37, Description = "Boleto Pagamento" },
                new Reasons { ReasonId = 38, Description = "Informe de rendimentos" },
                new Reasons { ReasonId = 39, Description = "E-mail Suspeito" },
                new Reasons { ReasonId = 40, Description = "Bloqueio judicial" },
                new Reasons { ReasonId = 41, Description = "Recarga Bilhete Único" },
                new Reasons { ReasonId = 42, Description = "Erro de Biometria" },
                new Reasons { ReasonId = 43, Description = "Sem Grupo de Acesso" },
                new Reasons { ReasonId = 44, Description = "Sem Cadastro de Loja" },
                new Reasons { ReasonId = 45, Description = "Proposta Recusada" },
                new Reasons { ReasonId = 46, Description = "Sem Limite para Beneficio" },
                new Reasons { ReasonId = 47, Description = "Erro Sistêmico" }
            );

    }

}
