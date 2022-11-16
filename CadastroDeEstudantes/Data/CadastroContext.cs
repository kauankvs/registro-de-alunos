using CadastroDeEstudantes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeEstudantes.Data
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options)
        {
        }

        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudante>().ToTable("Estudante");
            modelBuilder.Entity<Instituicao>().ToTable("Instituicao");
        }
    }
}
