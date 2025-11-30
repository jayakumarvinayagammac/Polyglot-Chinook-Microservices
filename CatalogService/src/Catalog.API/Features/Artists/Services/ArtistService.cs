using Catalog.API.Features.Artists.DTOs;
using Catalog.API.Models;

namespace Catalog.API.Features.Artists.Services;

public class ArtistService : IArtistService
{
    // In-memory store for demo purposes (replace with database)
    private static readonly List<Artist> Artists = new();
    private static int _idCounter = 1;

    public Task<IEnumerable<GetArtistDto>> GetAllAsync()
    {
        var result = Artists.Select(a => new GetArtistDto { ArtistId = a.ArtistId, Name = a.Name });
        return Task.FromResult(result.AsEnumerable());
    }

    public Task<GetArtistDto?> GetByIdAsync(int id)
    {
        var artist = Artists.FirstOrDefault(a => a.ArtistId == id);
        var result = artist == null ? null : new GetArtistDto { ArtistId = artist.ArtistId, Name = artist.Name };
        return Task.FromResult(result);
    }

    public Task<GetArtistDto> CreateAsync(CreateArtistDto dto)
    {
        var artist = new Artist { ArtistId = _idCounter++, Name = dto.Name };
        Artists.Add(artist);
        return Task.FromResult(new GetArtistDto { ArtistId = artist.ArtistId, Name = artist.Name });
    }

    public Task<bool> UpdateAsync(int id, CreateArtistDto dto)
    {
        var artist = Artists.FirstOrDefault(a => a.ArtistId == id);
        if (artist == null) return Task.FromResult(false);
        artist.Name = dto.Name;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var artist = Artists.FirstOrDefault(a => a.ArtistId == id);
        if (artist == null) return Task.FromResult(false);
        Artists.Remove(artist);
        return Task.FromResult(true);
    }
}
