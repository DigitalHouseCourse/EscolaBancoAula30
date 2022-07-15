using Microsoft.EntityFrameworkCore;
using Escola.Models;

namespace Escola.Models
{
    public class EscolaContext : DbContext
    {
        // Adicionando as tabelas no banco de dados.
        public DbSet<Instituicao> Instituicoes { get; set; }

        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instituicao>()
                .ToTable("Instituicoes")
                .HasKey(t => t.id);

            modelBuilder.Entity<Aluno>()
                .ToTable("Alunos")
                .HasKey(t => t.id);

            modelBuilder.Entity<Instituicao>()
                .HasMany(t => t.alunos);

        }

        public DbSet<Escola.Models.Aluno>? alunos { get; set; }
    }
}
