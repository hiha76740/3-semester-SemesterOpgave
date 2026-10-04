using AccomodationService.ApplicationLib.Extensions;
using AccomodationService.ApplicationLib.Handlers.Services;
using AccomodationService.InfrastructureLib.Extensions;
using AccomodationService.InfrastructureLib.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddHandlerDI();
builder.Services.AddDatabaseDI(builder.Configuration);
builder.Services.AddRepositoryDI();
builder.Services.AddServiceDI();
builder.Services.AddQueriesDI();
builder.Services.AddScoped<HttpClient>();

// TODO: replace with extension call
var imageDirectory = Path.Combine(builder.Environment.ContentRootPath, "Storage", "images");
builder.Services.AddScoped<IImageStorageService>(serviceProvider => new LocalImageStorageService(imageDirectory));

// TODO: replace with call when moved into shared
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)),
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = ctx =>
            {
                ctx.Request.Cookies.TryGetValue("accessToken", out var accessToken);
                if (string.IsNullOrEmpty(accessToken) == false)
                    ctx.Token = accessToken;

                return Task.CompletedTask;
            }
        };
    });

// TODO: replace with call when moved into shared
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorOrigin", policy =>
    {
        policy.WithOrigins(
            "https://localhost:7179",
            "https://localhost:8082")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Accomodation API";
        options.HideModels = true;
    });
}

// TODO: replace with call
Directory.CreateDirectory(imageDirectory);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imageDirectory),
    RequestPath = "/images"
});

//app.UseHttpsRedirection();
app.MapHealthChecks("health");

app.UseCors("AllowBlazorOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
