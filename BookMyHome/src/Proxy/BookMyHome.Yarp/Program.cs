using BookMyHome.Yarp.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("YARP"));

string corsPolicyName = "AllowBlazorOrigin";

builder.Services.AddBookMyHomeCors(corsPolicyName);

var app = builder.Build();

app.UseCors(corsPolicyName);
app.MapHealthChecks("health");
app.MapReverseProxy();

app.Run();