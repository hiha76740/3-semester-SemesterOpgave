using Microsoft.Extensions.FileProviders;

namespace AccomodationService.Api.Extensions;

public static class ImageDirectory
{
    public static string SetImageDirectory(this WebApplicationBuilder builder)
    {
        var imageDirectory = Path.Combine(builder.Environment.ContentRootPath, "Storage", "images");

        return imageDirectory;
    }

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
