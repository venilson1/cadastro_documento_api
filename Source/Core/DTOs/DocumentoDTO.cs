using System.ComponentModel.DataAnnotations;

namespace cadastro_documento_api.Source.Core.DTOs
{
    public class DocumentoDTO
    {
        [Required(ErrorMessage = "O Campo Código é obrigatório")]
        [RegularExpression("([0-9]+)", ErrorMessage = "O Campo Código é somento números")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "O Campo Processo é obrigatório")]
        public int ProcessoId { get; set; }
        [Required(ErrorMessage = "O Campo Título é obrigatório")]
        public int Titulo { get; set; }
        [Required(ErrorMessage = "O Campo Categoria é obrigatório")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "O Campo Arquivo é obrigatório")]
        public string Arquivo { get; set; }
    }
}
