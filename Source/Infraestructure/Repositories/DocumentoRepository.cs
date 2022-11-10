using cadastro_documento_api.Source.Core.Entities;
using cadastro_documento_api.Source.Core.Interfaces.Repositories;

namespace cadastro_documento_api.Source.Infraestructure.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        public Task<int> CountPage()
        {
            throw new NotImplementedException();
        }

        public Task<DocumentoEntity> Create(DocumentoEntity doc)
        {
            throw new NotImplementedException();
        }

        public Task<List<DocumentoEntity>> FindAll(int page)
        {
            throw new NotImplementedException();
        }

        public Task<DocumentoEntity> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
