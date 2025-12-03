using Catalog.API.Features.Genres.DTOs;
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

    private static async Task<IResult> GetGenreById(int id, IMediator mediator)
    {
        try
        {
            var genre = await mediator.Send(new Queries.GetGenreByIdQuery(id));
            return Results.Ok(genre);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> CreateGenre(CreateGenreDto dto, IMediator mediator)
    {
        var createdGenre = await mediator.Send(new Commands.CreateGenreCommand(dto.Name));
        return Results.Created($"/api/genres/{createdGenre.GenreId}", createdGenre);
    }

    private static async Task<IResult> UpdateGenre(int id, CreateGenreDto dto, IMediator mediator)
    {
        var success = await mediator.Send(new Commands.UpdateGenreCommand(id, dto.Name));
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteGenre(int id, IMediator mediator)
    {
        var success = await mediator.Send(new Commands.DeleteGenreCommand(id));
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }
}
