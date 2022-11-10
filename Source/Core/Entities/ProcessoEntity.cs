using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cadastro_documento_api.Source.Core.Entities
{
    public class ProcessoEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
        [JsonIgnore]
        public virtual DocumentoEntity Documento { get; set; }
    }
}
