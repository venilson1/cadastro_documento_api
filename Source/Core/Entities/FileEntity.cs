using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cadastro_documento_api.Source.Core.Entities
{
    public class FileEntity
    {
        public FileEntity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }
        public byte[] FileBytes { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        [JsonIgnore]
        public virtual DocumentoEntity Documeto { get; set; }

    }
}
