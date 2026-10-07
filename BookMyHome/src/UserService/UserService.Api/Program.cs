using BookMyHome.BuildingBlocksLib.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;
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
builder.Services.AddQueriesDI();

builder.Services.AddHealthChecks();

builder.Services.AddBookMyHomeAuthentication(builder);


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

//app.UseHttpsRedirection();
app.MapHealthChecks("health");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
