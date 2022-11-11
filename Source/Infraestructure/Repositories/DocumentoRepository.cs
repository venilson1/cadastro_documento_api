using cadastro_documento_api.Source.Core.Entities;
using cadastro_documento_api.Source.Core.Interfaces.Repositories;
using cadastro_documento_api.Source.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace cadastro_documento_api.Source.Infraestructure.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly CadastroDocumentosContex _dbContex;

        public DocumentoRepository(CadastroDocumentosContex dbContex)
        {
            _dbContex = dbContex;
        }

        public async Task<int> CountPage()
        {
            int total = _dbContex.Documento.Count();

            decimal totalPage = total / 8;

            totalPage = Math.Ceiling(totalPage);
            return (int)totalPage;
        }

        public async Task<DocumentoEntity> Create(DocumentoEntity doc)
        {
            await _dbContex.Documento.AddAsync(doc);
            await _dbContex.SaveChangesAsync();
            return doc;
        }

        public async Task<List<DocumentoEntity>> FindAll(int page)
        {
            return await _dbContex.Documento.Select(x => new DocumentoEntity {
                Id = x.Id,
                Arquivo = x.Arquivo,
                Categoria = x.Categoria,
                Codigo = x.Codigo,
                Titulo = x.Titulo,
                ProcessoId = x.ProcessoId,
                Processo = x.Processo,
            }).OrderBy(x => x.Titulo).AsNoTracking().Skip((page * 8)).Take(8).ToListAsync();
        }

        public async Task<DocumentoEntity> FindById(int id)
        {
            return await _dbContex.Documento.Select(x => new DocumentoEntity 
            { 
                Id = x.Id,
                Arquivo = x.Arquivo,
                Categoria = x.Categoria,
                Codigo = x.Codigo,
                Titulo = x.Titulo,
                ProcessoId = x.ProcessoId,
                Processo = x.Processo,
            }).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
