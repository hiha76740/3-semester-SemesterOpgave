using BookingService.ApplicationLib.Extensions;
using BookingService.InfrastructureLib.Extensions;
using BookMyHome.BuildingBlocksLib.DependencyInjection;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddHandlerDI();
builder.Services.AddDatabaseDI(builder.Configuration);
builder.Services.AddRepositoryDI();
builder.Services.AddUnitOfWorkDI();
builder.Services.AddQueriesDI();
builder.Services.AddServicesDI();
builder.Services.AddScoped<HttpClient>();

builder.Services.AddBookMyHomeAuthentication(builder);

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Booking API";
        options.HideModels = true;
    });
}

//app.UseHttpsRedirection();
app.MapHealthChecks("health");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
