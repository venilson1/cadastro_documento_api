using cadastro_documento_api.Source.Core.DTOs;
using cadastro_documento_api.Source.Core.Entities;
using cadastro_documento_api.Source.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_documento_api.Source.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoRepository _docRepository;
        private readonly IFileRepository _fileRepository;

        public DocumentoController(IDocumentoRepository docRepository, IFileRepository fileRepository)
        {
            _docRepository = docRepository;
            _fileRepository = fileRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentoEntity>>> FindAll(
            [FromQuery] int page = 0
        )
        {
            List<DocumentoEntity> docs = await _docRepository.FindAll(page);
            var totalPage = await _docRepository.CountPage();

            List<ReadDocumentoDTO> results = new();

            foreach(var doc in docs)
            {
                ReadDocumentoDTO dto = new();
                dto.Id = doc.Id;
                dto.Titulo = doc.Titulo;
                dto.Codigo = doc.Codigo;
                dto.Categoria = doc.Categoria;
                dto.ProcessoNome = doc.Processo.Nome;
                dto.ArquivoId = doc.ArquivoId;
                results.Add(dto);
            }


            return Ok(new
            {
                totalPage = totalPage,
                page = page,
                data = results,
            });
        }

        [HttpPost]
        public async Task<ActionResult<DocumentoEntity>> Create([FromForm] DocumentoDTO docDTO)
        {
            byte[] data = null;

            using (var stream = new MemoryStream())
            {
                await docDTO.Arquivo.CopyToAsync(stream);
                stream.ToArray();

                data = stream.ToArray();

                File(stream.ToArray(), docDTO.Arquivo.ContentType, docDTO.Arquivo.FileName);
            }

            FileEntity file = new()
            {
                FileBytes = data,
                FileName = docDTO.Arquivo.FileName,
                ContentType = docDTO.Arquivo.ContentType
            };

            await _fileRepository.Create(file);


            DocumentoEntity doc = new()
            {
                Codigo = docDTO.Codigo,
                Categoria = docDTO.Categoria,
                ArquivoId = file.Id,
                Titulo = docDTO.Titulo,
                ProcessoId = docDTO.ProcessoId,
                CriadoEm = DateTime.Now
            };

            await _docRepository.Create(doc);
            return CreatedAtAction(nameof(FindById), new { Id = doc.Id }, doc);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentoEntity>> FindById(Guid id)
        {
            DocumentoEntity doc = await _docRepository.FindById(id);
            if (doc == null) return NotFound();

            ReadDocumentoDTO dto = new();
            dto.Id = doc.Id;
            dto.Titulo = doc.Titulo;
            dto.Codigo = doc.Codigo;
            dto.Categoria = doc.Categoria;
            dto.ProcessoNome = doc.Processo.Nome;
            dto.ArquivoId = doc.ArquivoId;

            return Ok(dto);
        }
    }
}
