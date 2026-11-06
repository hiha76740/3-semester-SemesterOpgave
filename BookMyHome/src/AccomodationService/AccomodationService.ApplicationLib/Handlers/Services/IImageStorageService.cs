namespace AccomodationService.ApplicationLib.Handlers.Services;

/// <summary>
/// 
/// </summary>
public interface IImageStorageService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="imageStream"></param>
    /// <param name="extension"></param>
    /// <returns></returns>
    Task<string> SaveAsync(Stream imageStream, string extension);
}
