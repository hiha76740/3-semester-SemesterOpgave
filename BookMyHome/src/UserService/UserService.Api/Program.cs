using Scalar.AspNetCore;
using UserService.Api.DependencyInjection;
using UserService.ApplicationLib.Extensions;
using UserService.InfrastructureLib.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDatabaseDI(builder.Configuration);
builder.Services.AddHandlerDI();
builder.Services.AddAuthenTicationDI();
builder.Services.AddRepositoryDI();
builder.Services.AddInternalServiceDI();

builder.Services.AddHealthChecks();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorOrigin", policy =>
    {
        policy.WithOrigins("https://localhost:7179")
        .AllowAnyHeader()
        .AllowAnyMethod();

        policy.WithOrigins("https://localhost:8082")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "User Api";
        options.HideModels = true;
    });
}

app.UseHttpsRedirection();
app.MapHealthChecks("health");

app.UseCors("AllowBlazorOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
