using Catalog.API.Features.Artists.DTOs;
using MediatR;
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

    private static async Task<IResult> GetAllArtists(IMediator mediator)
    {
        var artists = await mediator.Send(new Queries.GetAllArtistQuery());
        return Results.Ok(artists);
    }

    private static async Task<IResult> GetArtistById(int id, IMediator mediator)
    {
        try
        {
            var artist = await mediator.Send(new Queries.GetArtistByIdQuery(id));
            return Results.Ok(artist);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> CreateArtist(CreateArtistDto dto, IMediator mediator)
    {
        var createdArtist = await mediator.Send(new Commands.CreateArtistCommand(dto));
        return Results.Created($"/api/artists/{createdArtist.ArtistId}", createdArtist);
    }

    private static async Task<IResult> UpdateArtist(int id, CreateArtistDto dto, IMediator mediator)
    {
        var success = await mediator.Send(new Commands.UpdateArtistCommand(id, dto.Name));
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteArtist(int id, IMediator mediator)
    {
        var success = await mediator.Send(new Commands.DeleteArtistCommand(id));
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }
}
