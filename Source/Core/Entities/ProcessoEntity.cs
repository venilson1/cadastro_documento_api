using System.ComponentModel.DataAnnotations;

namespace cadastro_documento_api.Source.Core.Entities
{
    public class ProcessoEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
        public DocumentoEntity Documento { get; set; }
    }
}
