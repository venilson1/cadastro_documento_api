using System.ComponentModel.DataAnnotations;


namespace cadastro_documento_api.Source.Core.Entities
{
    public class DocumentoEntity
    {

        public DocumentoEntity()
        {
            Id = Guid.NewGuid();
        }


        [Key]
        [Required]
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public Guid ArquivoId { get; set; }
        public virtual FileEntity Arquivo { get; set; }
        public DateTime CriadoEm { get; set; }
        public int ProcessoId { get; set; }
        public virtual ProcessoEntity Processo { get; set; }
    }
}
