using Catalog.API.Features.Albums.Endpoints;
using Catalog.API.Features.Artists.Endpoints;
using Catalog.API.Features.Genres.Endpoints;
using Catalog.API.Features.MediaTypes.Endpoints;
using Catalog.API.Features.Tracks.Endpoints;
using Catalog.API.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Force development environment for Swagger
builder.Environment.EnvironmentName = "Development";
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Catalog Service API",
        Version = "v1",
        Description = "RESTful API for managing catalog entities: Artists, Albums, Tracks, Genres, and MediaTypes",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Catalog Service Team",
            Email = "catalog@example.com"
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "MIT"
        }
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

// Register MediatR to discover query/command handlers
builder.Services.AddMediatR(typeof(Program).Assembly);

// Register feature services

// Configure EF Core DbContext for Chinook using the configured path
builder.Services.AddDbContext<ChinookDbContext>((sp, options) =>
{
    var cfg = sp.GetRequiredService<IConfiguration>();
    var path = cfg.GetValue<string>("ChinookDb:Path");
    if (string.IsNullOrWhiteSpace(path))
    {
        path = Path.Combine(AppContext.BaseDirectory, "data", "chinook.db");
    }
    var cs = $"Data Source={path}";
    options.UseSqlite(cs);
});

// Chinook DB repository (EF Core-backed)
builder.Services.AddScoped<IChinookRepository, ChinookRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog Service API v1");
    options.RoutePrefix = "swagger";
    options.DocumentTitle = "Catalog Service API Documentation";
});

app.MapGet("/", () => Results.Ok(new { Message = "Catalog API running. Visit /swagger for documentation." }))
   .WithName("Root");

// Map feature endpoints
app.MapArtistEndpoints();
app.MapAlbumEndpoints();
app.MapTrackEndpoints();
app.MapGenreEndpoints();
app.MapMediaTypeEndpoints();

app.Run();
