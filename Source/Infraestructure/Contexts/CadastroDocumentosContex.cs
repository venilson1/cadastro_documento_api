using cadastro_documento_api.Source.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace cadastro_documento_api.Source.Infraestructure.Contexts
{
    public class CadastroDocumentosContex : DbContext
    {
        public CadastroDocumentosContex(DbContextOptions<CadastroDocumentosContex> options) : base(options) { }

        public DbSet<ProcessoEntity> Processo { get; set; }
        public DbSet<DocumentoEntity> Documento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProcessoEntity>()
                .HasOne(processo => processo.Documento)
                .WithOne(documento => documento.Processo)
                .HasForeignKey<DocumentoEntity>(documento => documento.ProcessoId);

            modelBuilder.Entity<ProcessoEntity>().HasData(
                new ProcessoEntity { Id = 1, Nome = "A", CriadoEm = DateTime.Now },
                new ProcessoEntity { Id = 2, Nome = "B", CriadoEm = DateTime.Now },
                new ProcessoEntity { Id = 3, Nome = "C", CriadoEm = DateTime.Now },
                new ProcessoEntity { Id = 4, Nome = "D", CriadoEm = DateTime.Now }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
