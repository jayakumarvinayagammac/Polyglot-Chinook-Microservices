using Catalog.API.Features.Tracks.DTOs;

namespace Catalog.API.Features.Tracks.Services;

public interface ITrackService
{
    Task<IEnumerable<GetTrackDto>> GetAllAsync();
    Task<GetTrackDto?> GetByIdAsync(int id);
    Task<GetTrackDto> CreateAsync(CreateTrackDto dto);
    Task<bool> UpdateAsync(int id, CreateTrackDto dto);
    Task<bool> DeleteAsync(int id);
}
