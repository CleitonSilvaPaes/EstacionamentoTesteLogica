using Estacionamento.Interface;
using Estacionamento.Model;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Repositorio
{
    public class EstacionamentoContext : DbContext, IEstacionamentoContextFactory
    {
        public virtual DbSet<Veiculo> Veiculos { get; set; }
        public virtual DbSet<TabelaPreco> TabelasPrecos { get; set; }
        public virtual DbSet<Movimentacao> Movimentacoes { get; set; }

        public EstacionamentoContext Create()
        {
            return new EstacionamentoContext();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=estacionamento.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Refencia
            // https://learn.microsoft.com/pt-br/ef/core/modeling/keys?tabs=fluent-api

            modelBuilder.Entity<TabelaPreco>()
                .HasKey(t => t.Id); // Definindo a chave primária

            modelBuilder.Entity<Veiculo>()
                .HasKey(v => v.Id); // Definindo a chave primária

            modelBuilder.Entity<Movimentacao>()
                .HasKey(m => m.Id); // Definindo a chave primária

            // Configurando a relação entre Movimentacao e Veiculo
            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Veiculo)
                .WithMany()
                .HasForeignKey(m => m.VeiculoId)
                .OnDelete(DeleteBehavior.Cascade); // Configurando o comportamento de exclusão


            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.TabelaPreco)
                .WithMany()
                .HasForeignKey(m => m.TabelaPrecoId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
