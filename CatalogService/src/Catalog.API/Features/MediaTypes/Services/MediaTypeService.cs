using Catalog.API.Features.MediaTypes.DTOs;
using Catalog.API.Models;

namespace Catalog.API.Features.MediaTypes.Services;

public class MediaTypeService : IMediaTypeService
{
    private static readonly List<MediaType> MediaTypes = new();
    private static int _idCounter = 1;

    public Task<IEnumerable<GetMediaTypeDto>> GetAllAsync()
    {
        var result = MediaTypes.Select(m => new GetMediaTypeDto { MediaTypeId = m.MediaTypeId, Name = m.Name });
        return Task.FromResult(result.AsEnumerable());
    }

    public Task<GetMediaTypeDto?> GetByIdAsync(int id)
    {
        var mediaType = MediaTypes.FirstOrDefault(m => m.MediaTypeId == id);
        var result = mediaType == null ? null : new GetMediaTypeDto { MediaTypeId = mediaType.MediaTypeId, Name = mediaType.Name };
        return Task.FromResult(result);
    }

    public Task<GetMediaTypeDto> CreateAsync(CreateMediaTypeDto dto)
    {
        var mediaType = new MediaType { MediaTypeId = _idCounter++, Name = dto.Name };
        MediaTypes.Add(mediaType);
        return Task.FromResult(new GetMediaTypeDto { MediaTypeId = mediaType.MediaTypeId, Name = mediaType.Name });
    }

    public Task<bool> UpdateAsync(int id, CreateMediaTypeDto dto)
    {
        var mediaType = MediaTypes.FirstOrDefault(m => m.MediaTypeId == id);
        if (mediaType == null) return Task.FromResult(false);
        mediaType.Name = dto.Name;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var mediaType = MediaTypes.FirstOrDefault(m => m.MediaTypeId == id);
        if (mediaType == null) return Task.FromResult(false);
        MediaTypes.Remove(mediaType);
        return Task.FromResult(true);
    }
}
