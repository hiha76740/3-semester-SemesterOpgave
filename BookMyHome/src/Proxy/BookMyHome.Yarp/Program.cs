using BookMyHome.Yarp.Extensions;
using Microsoft.AspNetCore.Authentication.BearerToken;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHealthChecks();

string corsPolicyName = "BlazorCors";
builder.Services.AddBookMyHomeCors(corsPolicyName);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("YARP"));

builder.Services
    .AddAuthentication(BearerTokenDefaults.AuthenticationScheme)
    .AddBearerToken();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();
app.MapHealthChecks("health");
app.MapReverseProxy();

app.Run();