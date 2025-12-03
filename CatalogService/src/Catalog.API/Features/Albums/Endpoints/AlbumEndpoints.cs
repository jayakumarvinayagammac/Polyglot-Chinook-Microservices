using Catalog.API.Features.Albums.Commands;
using Catalog.API.Features.Albums.DTOs;
using MediatR;
namespace Catalog.API.Features.Albums.Endpoints;

public static class AlbumEndpoints
{
    public static void MapAlbumEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/albums")
            .WithName("Albums");

        group.MapGet("/", GetAllAlbums)
            .WithName("GetAllAlbums")
            .WithDescription("Retrieve all albums");
        group.MapGet("/{id}", GetAlbumById)
            .WithName("GetAlbumById")
            .WithDescription("Retrieve a specific album by ID");
        group.MapPost("/", CreateAlbum)
            .WithName("CreateAlbum")
            .WithDescription("Create a new album");
        group.MapPut("/{id}", UpdateAlbum)
            .WithName("UpdateAlbum")
            .WithDescription("Update an existing album");
        group.MapDelete("/{id}", DeleteAlbum)
            .WithName("DeleteAlbum")
            .WithDescription("Delete an album by ID");
    }

    private static async Task<IResult> GetAllAlbums(IMediator mediator)
    {
        var albums = await mediator.Send(new Queries.GetAllAlbumsQuery());
        return Results.Ok(albums);
    }

    private static async Task<IResult> GetAlbumById(int id, IMediator mediator)
    {
        try
        {
            var album = await mediator.Send(new Queries.GetAlbumByIdQuery(id));
            return Results.Ok(album);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> CreateAlbum(CreateAlbumDto dto, IMediator mediator)
    {
        var createdAlbum = await mediator.Send(new CreateAlbumCommand(dto));
        return Results.Created($"/api/albums/{createdAlbum.AlbumId}", createdAlbum);
    }

    private static async Task<IResult> UpdateAlbum(int id, CreateAlbumDto dto, IMediator mediator)
    {
        var success = await mediator.Send(new Commands.UpdateAlbumCommand(id, dto.Title, dto.ArtistId));
        if (!success) return Results.NotFound();
        return Results.NoContent();
        
    }

    private static async Task<IResult> DeleteAlbum(int id, IMediator mediator)
    {
        var success = await mediator.Send(new Commands.DeleteAlbumCommand(id));
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }
}
