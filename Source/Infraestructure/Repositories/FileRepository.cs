using cadastro_documento_api.Source.Core.Entities;
using cadastro_documento_api.Source.Core.Interfaces.Repositories;
using cadastro_documento_api.Source.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace cadastro_documento_api.Source.Infraestructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly CadastroDocumentosContex _dbContex;

        public FileRepository(CadastroDocumentosContex dbContex)
        {
            _dbContex = dbContex;
        }
        public async Task<FileEntity> Create(FileEntity file)
        {
            await _dbContex.File.AddAsync(file);
            await _dbContex.SaveChangesAsync();
            return file;
        }

        public async Task<FileEntity> FindById(Guid id)
        {
            return await _dbContex.File.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
