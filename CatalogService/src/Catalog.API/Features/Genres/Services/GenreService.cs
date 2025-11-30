using Catalog.API.Features.Genres.DTOs;
using Catalog.API.Models;

namespace Catalog.API.Features.Genres.Services;

public class GenreService : IGenreService
{
    private static readonly List<Genre> Genres = new();
    private static int _idCounter = 1;

    public Task<IEnumerable<GetGenreDto>> GetAllAsync()
    {
        var result = Genres.Select(g => new GetGenreDto { GenreId = g.GenreId, Name = g.Name });
        return Task.FromResult(result.AsEnumerable());
    }

    public Task<GetGenreDto?> GetByIdAsync(int id)
    {
        var genre = Genres.FirstOrDefault(g => g.GenreId == id);
        var result = genre == null ? null : new GetGenreDto { GenreId = genre.GenreId, Name = genre.Name };
        return Task.FromResult(result);
    }

    public Task<GetGenreDto> CreateAsync(CreateGenreDto dto)
    {
        var genre = new Genre { GenreId = _idCounter++, Name = dto.Name };
        Genres.Add(genre);
        return Task.FromResult(new GetGenreDto { GenreId = genre.GenreId, Name = genre.Name });
    }

    public Task<bool> UpdateAsync(int id, CreateGenreDto dto)
    {
        var genre = Genres.FirstOrDefault(g => g.GenreId == id);
        if (genre == null) return Task.FromResult(false);
        genre.Name = dto.Name;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var genre = Genres.FirstOrDefault(g => g.GenreId == id);
        if (genre == null) return Task.FromResult(false);
        Genres.Remove(genre);
        return Task.FromResult(true);
    }
}
