using cadastro_documento_api.Source.Core.DTOs;
using cadastro_documento_api.Source.Core.Entities;
using cadastro_documento_api.Source.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_documento_api.Source.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoRepository _docRepository;

        public DocumentoController(IDocumentoRepository docRepository)
        {
            _docRepository = docRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentoEntity>>> FindAll(
            [FromQuery] int page = 0
        )
        {
            List<DocumentoEntity> docs = await _docRepository.FindAll(page);
            var totalPage = await _docRepository.CountPage();

            return Ok(new
            {
                totalPage = totalPage,
                page = page,
                data = docs,
            });
        }

        [HttpPost]
        public async Task<ActionResult<DocumentoEntity>> Create([FromForm] DocumentoDTO docDTO)
        {
            using (var stream = new MemoryStream())
            {
                await docDTO.Arquivo.CopyToAsync(stream);
                stream.ToArray();

                File(stream.ToArray(), docDTO.Arquivo.ContentType, docDTO.Arquivo.FileName);
            }

            DocumentoEntity doc = new()
            {
                Codigo = docDTO.Codigo,
                Categoria = docDTO.Categoria,
                Arquivo = docDTO.Arquivo.ContentType,
                Titulo = docDTO.Titulo,
                ProcessoId = docDTO.ProcessoId,
                CriadoEm = DateTime.Now
            };

            await _docRepository.Create(doc);
            return CreatedAtAction(nameof(FindById), new { Id = doc.Id }, doc);
        }

        [HttpPost("upload")]
        public async Task<ActionResult<DocumentoEntity>> Upload([FromForm] ICollection<IFormFile> files)
        {

            return Ok(files);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentoEntity>> FindById(int id)
        {
            DocumentoEntity doc = await _docRepository.FindById(id);
            if (doc == null) return NotFound();
            return Ok(doc);
        }
    }
}
