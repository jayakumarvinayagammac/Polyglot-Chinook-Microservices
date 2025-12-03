using Catalog.API.Features.MediaTypes.DTOs;
using MediatR;
namespace Catalog.API.Features.MediaTypes.Endpoints;

public static class MediaTypeEndpoints
{
    public static void MapMediaTypeEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/mediatypes")
            .WithName("MediaTypes");

        group.MapGet("/", GetAllMediaTypes)
            .WithName("GetAllMediaTypes")
            .WithDescription("Retrieve all media types");
        group.MapGet("/{id}", GetMediaTypeById)
            .WithName("GetMediaTypeById")
            .WithDescription("Retrieve a specific media type by ID");
        group.MapPost("/", CreateMediaType)
            .WithName("CreateMediaType")
            .WithDescription("Create a new media type");
        group.MapPut("/{id}", UpdateMediaType)
            .WithName("UpdateMediaType")
            .WithDescription("Update an existing media type");
        group.MapDelete("/{id}", DeleteMediaType)
            .WithName("DeleteMediaType")
            .WithDescription("Delete a media type by ID");
    }

    private static async Task<IResult> GetAllMediaTypes(IMediator mediator)
    {
        var mediaTypes = await mediator.Send(new Queries.GetAllMediaTypesQuery());
        return Results.Ok(mediaTypes);
    }

    private static async Task<IResult> GetMediaTypeById(int id, IMediator mediator)
    {
        try
        {
            var mediaType = await mediator.Send(new Queries.GetMediaTypeByIdQuery(id));
            return Results.Ok(mediaType);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> CreateMediaType(CreateMediaTypeDto dto, IMediator mediator)
    {
        var createdMediaType = await mediator.Send(new Commands.CreateMediaTypeCommand(dto));
        return Results.Created($"/api/mediatypes/{createdMediaType.MediaTypeId}", createdMediaType);
    }

    private static async Task<IResult> UpdateMediaType(int id, CreateMediaTypeDto dto, IMediator mediator)
    {
        var success = await mediator.Send(new Commands.UpdateMediaTypeCommand(id, dto.Name));
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteMediaType(int id, IMediator mediator)
    {
        var success = await mediator.Send(new Commands.DeleteMediaTypeCommand(id));
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }
}
