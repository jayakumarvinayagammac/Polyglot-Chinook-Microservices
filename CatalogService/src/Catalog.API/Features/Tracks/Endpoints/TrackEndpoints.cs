using Catalog.API.Features.Tracks.DTOs;
using MediatR;

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

    private static async Task<IResult> GetAllTracks(IMediator mediator)
    {
        var tracks = await mediator.Send(new Queries.GetAllTracksQuery());
        return Results.Ok(tracks);
    }

    private static async Task<IResult> GetTrackById(int id, IMediator mediator)
    {
        try
        {
            var track = await mediator.Send(new Queries.GetTrackByIdQuery(id));
            return Results.Ok(track);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> CreateTrack(CreateTrackDto dto, IMediator mediator)
    {
        var createdTrack = await mediator.Send(new Commands.CreateTrackCommand(dto));
        return Results.Created($"/api/tracks/{createdTrack.TrackId}", createdTrack);
    }

    private static async Task<IResult> UpdateTrack(int id, CreateTrackDto dto, IMediator mediator)
    {
        var success = await mediator.Send(new Commands.UpdateTrackCommand(id, dto));
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteTrack(int id, IMediator mediator)
    {
        var success = await mediator.Send(new Commands.DeleteTrackCommand(id));
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }
}
