using System.ComponentModel.DataAnnotations;
using cadastro_documento_api.Source.Infraestructure.Util;

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
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O Campo Categoria é obrigatório")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "O Campo Arquivo é obrigatório")]
        [AllowedExtensionsAttributeService(new string[] { ".pdf", ".doc", ".xls", "docx", "xlsx" })]
        public IFormFile Arquivo { get; set; }
    }
}
