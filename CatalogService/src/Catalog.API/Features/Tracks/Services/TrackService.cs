using Catalog.API.Features.Tracks.DTOs;
using Catalog.API.Models;

namespace Catalog.API.Features.Tracks.Services;

public class TrackService : ITrackService
{
    private static readonly List<Track> Tracks = new();
    private static int _idCounter = 1;

    public Task<IEnumerable<GetTrackDto>> GetAllAsync()
    {
        var result = Tracks.Select(t => new GetTrackDto
        {
            TrackId = t.TrackId,
            Name = t.Name,
            AlbumId = t.AlbumId,
            GenreId = t.GenreId,
            MediaTypeId = t.MediaTypeId,
            Milliseconds = t.Milliseconds,
            UnitPrice = t.UnitPrice
        });
        return Task.FromResult(result.AsEnumerable());
    }

    public Task<GetTrackDto?> GetByIdAsync(int id)
    {
        var track = Tracks.FirstOrDefault(t => t.TrackId == id);
        var result = track == null ? null : new GetTrackDto
        {
            TrackId = track.TrackId,
            Name = track.Name,
            AlbumId = track.AlbumId,
            GenreId = track.GenreId,
            MediaTypeId = track.MediaTypeId,
            Milliseconds = track.Milliseconds,
            UnitPrice = track.UnitPrice
        };
        return Task.FromResult(result);
    }

    public Task<GetTrackDto> CreateAsync(CreateTrackDto dto)
    {
        var track = new Track
        {
            TrackId = _idCounter++,
            Name = dto.Name,
            AlbumId = dto.AlbumId,
            GenreId = dto.GenreId,
            MediaTypeId = dto.MediaTypeId,
            Milliseconds = dto.Milliseconds,
            UnitPrice = dto.UnitPrice
        };
        Tracks.Add(track);
        return Task.FromResult(new GetTrackDto
        {
            TrackId = track.TrackId,
            Name = track.Name,
            AlbumId = track.AlbumId,
            GenreId = track.GenreId,
            MediaTypeId = track.MediaTypeId,
            Milliseconds = track.Milliseconds,
            UnitPrice = track.UnitPrice
        });
    }

    public Task<bool> UpdateAsync(int id, CreateTrackDto dto)
    {
        var track = Tracks.FirstOrDefault(t => t.TrackId == id);
        if (track == null) return Task.FromResult(false);
        track.Name = dto.Name;
        track.AlbumId = dto.AlbumId;
        track.GenreId = dto.GenreId;
        track.MediaTypeId = dto.MediaTypeId;
        track.Milliseconds = dto.Milliseconds;
        track.UnitPrice = dto.UnitPrice;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var track = Tracks.FirstOrDefault(t => t.TrackId == id);
        if (track == null) return Task.FromResult(false);
        Tracks.Remove(track);
        return Task.FromResult(true);
    }
}
