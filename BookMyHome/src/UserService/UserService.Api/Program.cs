using Scalar.AspNetCore;
using UserService.ApplicationLib.Extensions;
using UserService.InfrastructureLib.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDatabaseDI(builder.Configuration);
builder.Services.AddHandlerDI();
builder.Services.AddAuthenTicationDI();
builder.Services.AddRepositoryDI();

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.MapHealthChecks("health");

app.UseAuthorization();

app.MapControllers();

app.Run();
