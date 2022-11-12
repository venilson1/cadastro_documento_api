using cadastro_documento_api.Source.Core.Entities;

namespace cadastro_documento_api.Source.Core.Interfaces.Repositories
{
    public interface IDocumentoRepository
    {
        Task<List<DocumentoEntity>> FindAll(int page);
        Task<DocumentoEntity> FindById(Guid id);
        Task<DocumentoEntity> Create(DocumentoEntity doc);
        Task<int> CountPage();
    }
}
