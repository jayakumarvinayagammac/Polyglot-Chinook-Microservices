using Catalog.API.Features.Albums.Endpoints;
using Catalog.API.Features.Albums.Services;
using Catalog.API.Features.Artists.Endpoints;
using Catalog.API.Features.Artists.Services;
using Catalog.API.Features.Genres.Endpoints;
using Catalog.API.Features.Genres.Services;
using Catalog.API.Features.MediaTypes.Endpoints;
using Catalog.API.Features.MediaTypes.Services;
using Catalog.API.Features.Tracks.Endpoints;
using Catalog.API.Features.Tracks.Services;

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

// Register feature services
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<ITrackService, TrackService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IMediaTypeService, MediaTypeService>();

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
