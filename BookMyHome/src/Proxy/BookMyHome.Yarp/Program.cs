using BookMyHome.Yarp.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

string corsPolicyName = "BlazorCors";
builder.Services.AddBookMyHomeCors(corsPolicyName);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("YARP"));

var app = builder.Build();

app.UseCors();
app.MapHealthChecks("health");
app.MapReverseProxy();

app.Run();