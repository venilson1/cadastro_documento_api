using cadastro_documento_api.Source.Core.Entities;
using cadastro_documento_api.Source.Core.Interfaces.Repositories;
using cadastro_documento_api.Source.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_documento_api.Source.Infraestructure.Services
{
    public class FileService : IFileService
    {
        private  IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<Guid> ExecuteAsync(IFormFile formfile)
        {
            byte[] data = null;

            using (var stream = new MemoryStream())
            {
                await formfile.CopyToAsync(stream);
                stream.ToArray();
                data = stream.ToArray();
            }

            FileEntity fileEntity = new()
            {
                FileBytes = data,
                FileName = formfile.FileName,
                ContentType = formfile.ContentType
            };

            await _fileRepository.Create(fileEntity);

            return fileEntity.Id;
        }
    }
}
