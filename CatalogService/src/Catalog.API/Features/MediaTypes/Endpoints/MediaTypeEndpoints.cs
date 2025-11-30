using Catalog.API.Features.MediaTypes.DTOs;
using Catalog.API.Features.MediaTypes.Services;

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

    private static async Task<IResult> GetAllMediaTypes(IMediaTypeService service)
    {
        var mediaTypes = await service.GetAllAsync();
        return Results.Ok(mediaTypes);
    }

    private static async Task<IResult> GetMediaTypeById(int id, IMediaTypeService service)
    {
        var mediaType = await service.GetByIdAsync(id);
        if (mediaType == null) return Results.NotFound();
        return Results.Ok(mediaType);
    }

    private static async Task<IResult> CreateMediaType(CreateMediaTypeDto dto, IMediaTypeService service)
    {
        var mediaType = await service.CreateAsync(dto);
        return Results.Created($"/api/mediatypes/{mediaType.MediaTypeId}", mediaType);
    }

    private static async Task<IResult> UpdateMediaType(int id, CreateMediaTypeDto dto, IMediaTypeService service)
    {
        var success = await service.UpdateAsync(id, dto);
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteMediaType(int id, IMediaTypeService service)
    {
        var success = await service.DeleteAsync(id);
        if (!success) return Results.NotFound();
        return Results.NoContent();
    }
}
