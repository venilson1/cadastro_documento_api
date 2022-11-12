using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace cadastro_documento_api.Source.Core.DTOs
{
    public class ReadDocumentoDTO
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public Guid ArquivoId { get; set; }
        public string ProcessoNome  { get; set; }
    }
}
