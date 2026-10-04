using AccomodationService.ApplicationLib.Handlers.Services;

namespace AccomodationService.InfrastructureLib.Services
{
    public class LocalImageStorageService(string imageDirectory) : IImageStorageService
    {
        async Task<string> IImageStorageService.SaveAsync(Stream imageStream, string extension)
        {
            extension = extension.ToLowerInvariant();

            if (extension != ".jpg" &&
                extension != ".jpeg" &&
                extension != ".pgn"
                )
                throw new ArgumentException("Only JPG- and PNG-Pictures are allowed", nameof(extension));

            Directory.CreateDirectory(imageDirectory);

            var fileName = $"{Guid.NewGuid():N}{extension}";

            var filePath = Path.Combine(imageDirectory, fileName);

            await using var fileStream = new FileStream(
                filePath,
                FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None,
                bufferSize: 81920,
                useAsync: true
                );

            try
            {
                await imageStream.CopyToAsync(fileStream);
            }
            catch (Exception)
            {
                await fileStream.DisposeAsync();
                File.Delete(filePath);
                throw;
            }

            return fileName;
        }
    }
}
