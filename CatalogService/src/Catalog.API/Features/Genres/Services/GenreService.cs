using Catalog.API.Features.Genres.DTOs;
using Catalog.API.Infrastructure;

namespace Catalog.API.Features.Genres.Services;

public class GenreService : IGenreService
{
    private readonly IChinookRepository _repository;

    public GenreService(IChinookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetGenreDto>> GetAllAsync()
    {
        var genres = await _repository.GetAllGenresAsync();
        return genres;
    }

    public async Task<GetGenreDto?> GetByIdAsync(int id)
    {
        var genre = await _repository.GetGenreByIdAsync(id);
        return genre;
    }

    public async Task<GetGenreDto> CreateAsync(CreateGenreDto dto)
    {
        var genreId = await _repository.InsertGenreAsync(dto.Name);
        var createdGenre = await _repository.GetGenreByIdAsync((int)genreId);
        return createdGenre ?? new GetGenreDto { GenreId = (int)genreId, Name = dto.Name };
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
