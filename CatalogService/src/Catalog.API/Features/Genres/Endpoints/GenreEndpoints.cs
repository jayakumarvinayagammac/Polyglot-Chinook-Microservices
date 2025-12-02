using Catalog.API.Features.Genres.DTOs;
using Catalog.API.Features.Genres.Services;
using MediatR;

namespace Catalog.API.Features.Genres.Endpoints;

public static class GenreEndpoints
{
    public static void MapGenreEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/genres")
            .WithName("Genres");

        group.MapGet("/", GetAllGenres)
            .WithName("GetAllGenres")
            .WithDescription("Retrieve all genres");
        group.MapGet("/{id}", GetGenreById)
            .WithName("GetGenreById")
            .WithDescription("Retrieve a specific genre by ID");
        group.MapPost("/", CreateGenre)
            .WithName("CreateGenre")
            .WithDescription("Create a new genre");
        group.MapPut("/{id}", UpdateGenre)
            .WithName("UpdateGenre")
            .WithDescription("Update an existing genre");
        group.MapDelete("/{id}", DeleteGenre)
            .WithName("DeleteGenre")
            .WithDescription("Delete a genre by ID");
    }

    private static async Task<IResult> GetAllGenres(IMediator mediator)
    {
        var genres = await mediator.Send(new Queries.GetAllGenresQuery());
        return Results.Ok(genres);
    }

    private static async Task<IResult> GetGenreById(int id, IGenreService service)
    {
        var genre = await service.GetByIdAsync(id);
        if (genre == null) return Results.NotFound();
        return Results.Ok(genre);
    }

    private static async Task<IResult> CreateGenre(CreateGenreDto dto, IGenreService service)
    {
        var genre = await service.CreateAsync(dto);
        return Results.Created($"/api/genres/{genre.GenreId}", genre);
    }

    private static async Task<IResult> UpdateGenre(int id, CreateGenreDto dto, IGenreService service)
    {
        var success = await service.UpdateAsync(id, dto);
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteGenre(int id, IGenreService service)
    {
        var success = await service.DeleteAsync(id);
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }
}
