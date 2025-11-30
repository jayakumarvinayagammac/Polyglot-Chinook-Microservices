using Catalog.API.Features.Artists.DTOs;

namespace Catalog.API.Features.Artists.Services;

public interface IArtistService
{
    Task<IEnumerable<GetArtistDto>> GetAllAsync();
    Task<GetArtistDto?> GetByIdAsync(int id);
    Task<GetArtistDto> CreateAsync(CreateArtistDto dto);
    Task<bool> UpdateAsync(int id, CreateArtistDto dto);
    Task<bool> DeleteAsync(int id);
}
