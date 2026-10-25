using EmailService.ApplicationLib.Extensions;
using EmailService.InfrastructureLib.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHandlerDI();
builder.Services.AddServiceDI();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddHealthChecks();

builder.Services.AddSingleton(builder.Configuration);


var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.MapHealthChecks("health");

app.UseCloudEvents();
app.UseAuthorization();
app.MapControllers();
app.MapSubscribeHandler();

app.Run();
