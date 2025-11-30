using Catalog.API.Features.Genres.DTOs;

namespace Catalog.API.Features.Genres.Services;

public interface IGenreService
{
    Task<IEnumerable<GetGenreDto>> GetAllAsync();
    Task<GetGenreDto?> GetByIdAsync(int id);
    Task<GetGenreDto> CreateAsync(CreateGenreDto dto);
    Task<bool> UpdateAsync(int id, CreateGenreDto dto);
    Task<bool> DeleteAsync(int id);
}
