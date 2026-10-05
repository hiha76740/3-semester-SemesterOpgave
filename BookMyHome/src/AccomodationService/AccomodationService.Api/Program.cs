using AccomodationService.Api.Extensions;
using AccomodationService.ApplicationLib.Extensions;
using AccomodationService.InfrastructureLib.Extensions;
using BookMyHome.BuildingBlocksLib.DependencyInjection;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var imageDirectory = builder.SetImageDirectory();

builder.Services.AddHandlerDI();
builder.Services.AddDatabaseDI(builder.Configuration);
builder.Services.AddRepositoryDI();
builder.Services.AddServiceDI(imageDirectory);
builder.Services.AddQueriesDI();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddBookMyHomeAuthentication(builder);

var corsPolicyName = "AllowBlazorOrigin";
builder.Services.AddBookMyHomeCors(corsPolicyName);

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Accomodation API";
        options.HideModels = true;
    });
}

app.AddStaticImageFiles(imageDirectory);

//app.UseHttpsRedirection();
app.MapHealthChecks("health");

app.UseCors(corsPolicyName);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
