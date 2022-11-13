using cadastro_documento_api.Source.Core.DTOs;
using cadastro_documento_api.Source.Core.Entities;
using cadastro_documento_api.Source.Core.Interfaces.Repositories;
using cadastro_documento_api.Source.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_documento_api.Source.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoRepository _docRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IFileService _fileService;

        public DocumentoController(IDocumentoRepository docRepository, IFileService fileService, IFileRepository fileRepository)
        {
            _docRepository = docRepository;
            _fileService = fileService;
            _fileRepository = fileRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentoEntity>>> FindAll()
        {
            List<DocumentoEntity> docs = await _docRepository.FindAll();

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
                data = results,
            });
        }

        [HttpPost]
        public async Task<ActionResult<DocumentoEntity>> Create([FromForm] DocumentoDTO docDTO)
        {
            var isCode = await _docRepository.VerifyCode(docDTO.Codigo);

            if (isCode != null) return BadRequest(new {Errors = new { Codigo = new string[1] { "Código já existe na base de dados" } } });

            Guid fileId = await _fileService.ExecuteAsync(docDTO.Arquivo);
            //File(stream.ToArray(), docDTO.Arquivo.ContentType, docDTO.Arquivo.FileName);

            DocumentoEntity doc = new()
            {
                Codigo = docDTO.Codigo,
                Categoria = docDTO.Categoria,
                ArquivoId = fileId,
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

        [HttpGet("{arquivoId}/download")]
        public async Task<ActionResult<DocumentoEntity>> Download(Guid arquivoId)
        {
            FileEntity file = await _fileRepository.FindById(arquivoId);

            if (file == null) return NotFound();

            return File(file.FileBytes, file.ContentType, file.FileName);
        }
    }
}
