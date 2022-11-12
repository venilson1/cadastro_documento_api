namespace cadastro_documento_api.Source.Core.Interfaces.Services
{
    public interface IFileService
    {
        Task<Guid> ExecuteAsync(IFormFile formfile);
    }
}
