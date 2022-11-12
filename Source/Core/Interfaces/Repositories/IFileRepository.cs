using cadastro_documento_api.Source.Core.Entities;

namespace cadastro_documento_api.Source.Core.Interfaces.Repositories
{
    public interface IFileRepository
    {
        Task<FileEntity> Create(FileEntity file);
        Task<FileEntity> FindById(Guid id);
    }
}
