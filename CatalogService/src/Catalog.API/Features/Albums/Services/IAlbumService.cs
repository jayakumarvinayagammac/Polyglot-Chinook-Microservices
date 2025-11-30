using Catalog.API.Features.Albums.DTOs;

namespace Catalog.API.Features.Albums.Services;

public interface IAlbumService
{
    Task<IEnumerable<GetAlbumDto>> GetAllAsync();
    Task<GetAlbumDto?> GetByIdAsync(int id);
    Task<GetAlbumDto> CreateAsync(CreateAlbumDto dto);
    Task<bool> UpdateAsync(int id, CreateAlbumDto dto);
    Task<bool> DeleteAsync(int id);
}
