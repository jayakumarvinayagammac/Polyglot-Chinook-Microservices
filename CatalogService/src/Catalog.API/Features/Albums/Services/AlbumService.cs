using Catalog.API.Features.Albums.DTOs;
using Catalog.API.Models;

namespace Catalog.API.Features.Albums.Services;

public class AlbumService : IAlbumService
{
    private static readonly List<Album> Albums = new();
    private static int _idCounter = 1;

    public Task<IEnumerable<GetAlbumDto>> GetAllAsync()
    {
        var result = Albums.Select(a => new GetAlbumDto { AlbumId = a.AlbumId, Title = a.Title, ArtistId = a.ArtistId });
        return Task.FromResult(result.AsEnumerable());
    }

    public Task<GetAlbumDto?> GetByIdAsync(int id)
    {
        var album = Albums.FirstOrDefault(a => a.AlbumId == id);
        var result = album == null ? null : new GetAlbumDto { AlbumId = album.AlbumId, Title = album.Title, ArtistId = album.ArtistId };
        return Task.FromResult(result);
    }

    public Task<GetAlbumDto> CreateAsync(CreateAlbumDto dto)
    {
        var album = new Album { AlbumId = _idCounter++, Title = dto.Title, ArtistId = dto.ArtistId };
        Albums.Add(album);
        return Task.FromResult(new GetAlbumDto { AlbumId = album.AlbumId, Title = album.Title, ArtistId = album.ArtistId });
    }

    public Task<bool> UpdateAsync(int id, CreateAlbumDto dto)
    {
        var album = Albums.FirstOrDefault(a => a.AlbumId == id);
        if (album == null) return Task.FromResult(false);
        album.Title = dto.Title;
        album.ArtistId = dto.ArtistId;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var album = Albums.FirstOrDefault(a => a.AlbumId == id);
        if (album == null) return Task.FromResult(false);
        Albums.Remove(album);
        return Task.FromResult(true);
    }
}
