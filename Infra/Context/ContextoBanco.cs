using controle_jornada.Models;
using Microsoft.EntityFrameworkCore;

namespace controle_jornada.Infra.Context
{
    public class ContextoBanco : DbContext
    {
        public DbSet<AppVersao> AppVersoes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Versao> Versoes { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<EntradaLocal> EntradasLocais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=cjDB;Username=root;Password=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projeto>()
                .HasMany(p => p.Versoes)
                .WithOne(v => v.Projeto)
                .HasForeignKey(v => v.ProjetoId);

            modelBuilder.Entity<Versao>()
                .HasKey(v => new { v.Id, v.ProjetoId });

            modelBuilder.Entity<Versao>()
                .HasMany(v => v.Tarefas)
                .WithOne(t => t.Versao)
                .HasForeignKey(t => new { t.VersaoId, t.ProjetoVersaoId });

            modelBuilder.Entity<Tarefa>()
                .HasKey(t => new { t.Id, t.UsuarioId });

            modelBuilder.Entity<Tarefa>()
                .HasMany(t => t.Entradas)
                .WithOne(e => e.Tarefa)
                .HasForeignKey(e => new { e.TarefaId, e.TarefaUsuarioId });

            modelBuilder.Entity<Tarefa>()
                .HasMany(t => t.EntradasLocais)
                .WithOne(le => le.Tarefa)
                .HasForeignKey(le => new { le.TarefaId, le.TarefaUsuarioId });

            base.OnModelCreating(modelBuilder); 
        }
    }
}
