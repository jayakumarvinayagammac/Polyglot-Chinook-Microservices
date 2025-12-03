using Catalog.API.Features.Genres.DTOs;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Genres.Services;

public interface IGenreService
{
    Task<IEnumerable<GetGenreDto>> GetAllAsync();
    Task<GetGenreDto?> GetByIdAsync(int id);
    Task<GetGenreDto> CreateAsync(CreateGenreDto dto);
    Task<bool> UpdateAsync(int id, CreateGenreDto dto);
    Task<bool> DeleteAsync(int id);
}

public class GenreService : IGenreService
{
    private readonly IChinookRepository _repository;

    public GenreService(IChinookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetGenreDto>> GetAllAsync()
    {
        return await _repository.GetAllGenresAsync();
    }

    public async Task<GetGenreDto?> GetByIdAsync(int id)
    {
        return await _repository.GetGenreByIdAsync(id);
    }

    public async Task<GetGenreDto> CreateAsync(CreateGenreDto dto)
    {
        var id = await _repository.InsertGenreAsync(dto.Name);
        var created = await _repository.GetGenreByIdAsync((int)id);
        return created ?? new GetGenreDto { GenreId = (int)id, Name = dto.Name };
    }

    public async Task<bool> UpdateAsync(int id, CreateGenreDto dto)
    {
        return await _repository.UpdateGenreAsync(id, dto.Name);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteGenreAsync(id);
    }
}
