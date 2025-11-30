using Catalog.API.Features.MediaTypes.DTOs;

namespace Catalog.API.Features.MediaTypes.Services;

public interface IMediaTypeService
{
    Task<IEnumerable<GetMediaTypeDto>> GetAllAsync();
    Task<GetMediaTypeDto?> GetByIdAsync(int id);
    Task<GetMediaTypeDto> CreateAsync(CreateMediaTypeDto dto);
    Task<bool> UpdateAsync(int id, CreateMediaTypeDto dto);
    Task<bool> DeleteAsync(int id);
}
