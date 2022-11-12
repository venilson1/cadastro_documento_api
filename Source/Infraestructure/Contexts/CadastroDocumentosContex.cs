using cadastro_documento_api.Source.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace cadastro_documento_api.Source.Infraestructure.Contexts
{
    public class CadastroDocumentosContex : DbContext
    {
        public CadastroDocumentosContex(DbContextOptions<CadastroDocumentosContex> options) : base(options) { }

        public DbSet<ProcessoEntity> Processo { get; set; }
        public DbSet<DocumentoEntity> Documento { get; set; }

        public DbSet<FileEntity> File { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DocumentoEntity>()
                .HasOne(documento => documento.Processo)
                .WithMany(processo => processo.Documentos)
                .HasForeignKey(documento => documento.ProcessoId);

            modelBuilder.Entity<DocumentoEntity>()
            .HasOne(documento => documento.Arquivo)
            .WithOne(arquivo => arquivo.Documeto)
            .HasForeignKey<DocumentoEntity>(documento => documento.ArquivoId);

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
