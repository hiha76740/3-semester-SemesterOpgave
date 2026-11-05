namespace AccomodationService.ApplicationLib.Handlers.Services;

public interface IImageStorageService
{
    Task<string> SaveAsync(Stream imageStream, string extension);
}
