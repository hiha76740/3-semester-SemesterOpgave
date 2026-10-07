var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("YARP"));

var app = builder.Build();

app.MapHealthChecks("health");
app.MapReverseProxy();

app.Run();