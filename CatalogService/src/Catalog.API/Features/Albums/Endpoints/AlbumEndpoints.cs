using Catalog.API.Features.Albums.DTOs;
using Catalog.API.Features.Albums.Services;

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

    private static async Task<IResult> GetAllAlbums(IAlbumService service)
    {
        var albums = await service.GetAllAsync();
        return Results.Ok(albums);
    }

    private static async Task<IResult> GetAlbumById(int id, IAlbumService service)
    {
        var album = await service.GetByIdAsync(id);
        if (album == null) return Results.NotFound();
        return Results.Ok(album);
    }

    private static async Task<IResult> CreateAlbum(CreateAlbumDto dto, IAlbumService service)
    {
        var album = await service.CreateAsync(dto);
        return Results.Created($"/api/albums/{album.AlbumId}", album);
    }

    private static async Task<IResult> UpdateAlbum(int id, CreateAlbumDto dto, IAlbumService service)
    {
        var success = await service.UpdateAsync(id, dto);
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteAlbum(int id, IAlbumService service)
    {
        var success = await service.DeleteAsync(id);
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }
}
