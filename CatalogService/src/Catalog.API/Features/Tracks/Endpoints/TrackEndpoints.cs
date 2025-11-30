using Catalog.API.Features.Tracks.DTOs;
using Catalog.API.Features.Tracks.Services;

namespace Catalog.API.Features.Tracks.Endpoints;

public static class TrackEndpoints
{
    public static void MapTrackEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/tracks")
            .WithName("Tracks");

        group.MapGet("/", GetAllTracks)
            .WithName("GetAllTracks")
            .WithDescription("Retrieve all tracks");
        group.MapGet("/{id}", GetTrackById)
            .WithName("GetTrackById")
            .WithDescription("Retrieve a specific track by ID");
        group.MapPost("/", CreateTrack)
            .WithName("CreateTrack")
            .WithDescription("Create a new track");
        group.MapPut("/{id}", UpdateTrack)
            .WithName("UpdateTrack")
            .WithDescription("Update an existing track");
        group.MapDelete("/{id}", DeleteTrack)
            .WithName("DeleteTrack")
            .WithDescription("Delete a track by ID");
    }

    private static async Task<IResult> GetAllTracks(ITrackService service)
    {
        var tracks = await service.GetAllAsync();
        return Results.Ok(tracks);
    }

    private static async Task<IResult> GetTrackById(int id, ITrackService service)
    {
        var track = await service.GetByIdAsync(id);
        if (track == null) return Results.NotFound();
        return Results.Ok(track);
    }

    private static async Task<IResult> CreateTrack(CreateTrackDto dto, ITrackService service)
    {
        var track = await service.CreateAsync(dto);
        return Results.Created($"/api/tracks/{track.TrackId}", track);
    }

    private static async Task<IResult> UpdateTrack(int id, CreateTrackDto dto, ITrackService service)
    {
        var success = await service.UpdateAsync(id, dto);
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteTrack(int id, ITrackService service)
    {
        var success = await service.DeleteAsync(id);
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }
}
