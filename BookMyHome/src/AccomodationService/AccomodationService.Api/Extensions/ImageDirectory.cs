using Microsoft.Extensions.FileProviders;

namespace AccomodationService.Api.Extensions;

/// <summary>
/// 
/// </summary>
public static class ImageDirectory
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static string SetImageDirectory(this WebApplicationBuilder builder)
    {
        var imageDirectory = Path.Combine(builder.Environment.ContentRootPath, "Storage", "images");

        return imageDirectory;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="imageDirectory"></param>
    /// <returns></returns>
    public static WebApplication AddStaticImageFiles(this WebApplication app, string imageDirectory)
    {
        Directory.CreateDirectory(imageDirectory);
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(imageDirectory),
            RequestPath = "/images"
        });

        return app;
    }
}
