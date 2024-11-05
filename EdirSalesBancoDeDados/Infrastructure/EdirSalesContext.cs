using EdirSalesBancoDeDados.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdirSalesBancoDeDados.Infrastructure
{
    public class EdirSalesContext : DbContext
    {
        public EdirSalesContext(DbContextOptions options) : base(options) { }

        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Municipe> Municipes { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EdirSalesContext).Assembly);

            // muito para muito, relacionamento entre grupo e municipe informo para o EF nao criar as tabelas pois ja existe
            modelBuilder.Entity<Grupo>()
                .HasMany(g => g.Municipes)
                .WithMany(m => m.Grupos)
                .UsingEntity<Dictionary<string, object>>(
                "MunicipeGrupo", // Nome da tabela deve corresponder ao que foi configurado no FluentMigrator
                j => j.HasOne<Municipe>().WithMany().HasForeignKey("MunicipeId"),
                j => j.HasOne<Grupo>().WithMany().HasForeignKey("GrupoId")
                );

            modelBuilder.Entity<Municipe>()
                .HasMany(m => m.Solicitacoes)
                .WithMany(s => s.Municipes)
                .UsingEntity<Dictionary<string, object>>(
                "MunicipeSolicitacao",
                j => j.HasOne<Solicitacao>().WithMany().HasForeignKey("SolicitacaoId"),
                j => j.HasOne<Municipe>().WithMany().HasForeignKey("MunicipeId")
                );

            modelBuilder.Entity<Solicitacao>()
                .HasMany(s => s.Grupos)
                .WithMany(g => g.Solicitacoes)
                .UsingEntity<Dictionary<string, object>>(
                "SolicitacaoGrupo",
                j => j.HasOne<Grupo>().WithMany().HasForeignKey("GrupoId"),
                j => j.HasOne<Solicitacao>().WithMany().HasForeignKey("SolicitacaoId")
            );
        }

    }
}
