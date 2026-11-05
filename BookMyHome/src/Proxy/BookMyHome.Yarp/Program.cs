using BookMyHome.BuildingBlocksLib.DependencyInjection;
using BookMyHome.Yarp.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHealthChecks();

string corsPolicyName = "BlazorCors";
builder.Services.AddBookMyHomeCors(corsPolicyName);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("YARP"));

builder.Services.AddBookMyHomeAuthentication(builder);

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("health");
app.MapReverseProxy();

app.Run();