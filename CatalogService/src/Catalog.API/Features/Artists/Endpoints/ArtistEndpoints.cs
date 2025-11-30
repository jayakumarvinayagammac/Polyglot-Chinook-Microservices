using Catalog.API.Features.Artists.DTOs;
using Catalog.API.Features.Artists.Services;

namespace Catalog.API.Features.Artists.Endpoints;

public static class ArtistEndpoints
{
    public static void MapArtistEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/artists")
            .WithName("Artists");

        group.MapGet("/", GetAllArtists)
            .WithName("GetAllArtists")
            .WithDescription("Retrieve all artists");
        group.MapGet("/{id}", GetArtistById)
            .WithName("GetArtistById")
            .WithDescription("Retrieve a specific artist by ID");
        group.MapPost("/", CreateArtist)
            .WithName("CreateArtist")
            .WithDescription("Create a new artist");
        group.MapPut("/{id}", UpdateArtist)
            .WithName("UpdateArtist")
            .WithDescription("Update an existing artist");
        group.MapDelete("/{id}", DeleteArtist)
            .WithName("DeleteArtist")
            .WithDescription("Delete an artist by ID");
    }

    private static async Task<IResult> GetAllArtists(IArtistService service)
    {
        var artists = await service.GetAllAsync();
        return Results.Ok(artists);
    }

    private static async Task<IResult> GetArtistById(int id, IArtistService service)
    {
        var artist = await service.GetByIdAsync(id);
        if (artist == null) return Results.NotFound();
        return Results.Ok(artist);
    }

    private static async Task<IResult> CreateArtist(CreateArtistDto dto, IArtistService service)
    {
        var artist = await service.CreateAsync(dto);
        return Results.Created($"/api/artists/{artist.ArtistId}", artist);
    }

    private static async Task<IResult> UpdateArtist(int id, CreateArtistDto dto, IArtistService service)
    {
        var success = await service.UpdateAsync(id, dto);
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteArtist(int id, IArtistService service)
    {
        var success = await service.DeleteAsync(id);
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }
}
