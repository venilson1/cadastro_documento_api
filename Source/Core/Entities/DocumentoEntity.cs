﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cadastro_documento_api.Source.Core.Entities
{
    public class DocumentoEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Arquivo { get; set; }
        public DateTime CriadoEm { get; set; }
        public int ProcessoId { get; set; }
        public virtual ProcessoEntity Processo { get; set; }
    }
}
