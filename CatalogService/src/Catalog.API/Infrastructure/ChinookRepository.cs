using Microsoft.Data.Sqlite;
using Catalog.API.Features.Genres.DTOs;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Models;
using Catalog.API.Features.Artists.DTOs;
using Catalog.API.Features.Albums.DTOs;
using Catalog.API.Features.MediaTypes.DTOs;
using Catalog.API.Features.Tracks.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Catalog.API.Infrastructure;

public class ChinookRepository : IChinookRepository
{
    private readonly string _dbPath;

    private readonly ChinookDbContext _dbContext;

    public ChinookRepository(ChinookDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        // Derive the path from the underlying connection if possible
        try
        {
            _dbPath = _dbContext.Database.GetDbConnection().DataSource ?? Path.Combine(AppContext.BaseDirectory, "chinook.db");
        }
        catch
        {
            _dbPath = Path.Combine(AppContext.BaseDirectory, "chinook.db");
        }
    }

    public string DbPath => _dbPath;

    public SqliteConnection CreateConnection()
    {
        var cs = new SqliteConnectionStringBuilder { DataSource = _dbPath }.ToString();
        return new SqliteConnection(cs);
    }

    public async Task<IEnumerable<GetGenreDto>> GetAllGenresAsync()
    {
        var genres = await _dbContext.Genres.AsNoTracking().ToListAsync();
        return genres.Select(g => new GetGenreDto { GenreId = g.GenreId, Name = g.Name });
    }

    public async Task<GetGenreDto?> GetGenreByIdAsync(int id)
    {
        var g = await _dbContext.Genres.AsNoTracking().FirstOrDefaultAsync(x => x.GenreId == id);
        if (g == null) return null;
        return new GetGenreDto { GenreId = g.GenreId, Name = g.Name };
    }

    public async Task<int> InsertGenreAsync(string name)
    {
        var entity = new Genre { Name = name ?? string.Empty };
        _dbContext.Genres.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity.GenreId;
    }

    public async Task<bool> UpdateGenreAsync(int id, string name)
    {
        var entity = await _dbContext.Genres.FindAsync(id);
        if (entity == null) return false;
        entity.Name = name ?? string.Empty;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteGenreAsync(int id)
    {
        var entity = await _dbContext.Genres.FindAsync(id);
        if (entity == null) return false;
        _dbContext.Genres.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<GetArtistDto>> GetAllArtistsAsync()
    {
        var artists = await _dbContext.Artists.AsNoTracking().ToListAsync();
        return artists.Select(a => new GetArtistDto { ArtistId = a.ArtistId, Name = a.Name });
    }

    public async Task<GetArtistDto?> GetArtistByIdAsync(int id)
    {
        var a = await _dbContext.Artists.AsNoTracking().FirstOrDefaultAsync(x => x.ArtistId == id);
        if (a == null) return null;
        return new GetArtistDto { ArtistId = a.ArtistId, Name = a.Name };
    }

    public async Task<int> InsertArtistAsync(string name)
    {
        var entity = new Artist { Name = name ?? string.Empty };
        _dbContext.Artists.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity.ArtistId;
    }

    public async Task<bool> UpdateArtistAsync(int id, string name)
    {
        var entity = await _dbContext.Artists.FindAsync(id);
        if (entity == null) return false;
        entity.Name = name ?? string.Empty;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteArtistAsync(int id)
    {
        var entity = await _dbContext.Artists.FindAsync(id);
        if (entity == null) return false;
        _dbContext.Artists.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<GetAlbumDto>> GetAllAlbumsAsync()
    {
        var albums = await _dbContext.Albums.AsNoTracking().ToListAsync();
        return albums.Select(a => new GetAlbumDto { AlbumId = a.AlbumId, Title = a.Title, ArtistId = a.ArtistId });
    }

    public async Task<GetAlbumDto?> GetAlbumByIdAsync(int id)
    {
        var a = await _dbContext.Albums.AsNoTracking().FirstOrDefaultAsync(x => x.AlbumId == id);
        if (a == null) return null;
        return new GetAlbumDto { AlbumId = a.AlbumId, Title = a.Title, ArtistId = a.ArtistId };
    }

    public async Task<int> InsertAlbumAsync(string title, int artistId)
    {
        var entity = new Album { Title = title ?? string.Empty, ArtistId = artistId };
        _dbContext.Albums.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity.AlbumId;
    }

    public async Task<bool> UpdateAlbumAsync(int id, string title, int artistId)
    {
        var entity = await _dbContext.Albums.FindAsync(id);
        if (entity == null) return false;
        entity.Title = title ?? string.Empty;
        entity.ArtistId = artistId;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAlbumAsync(int id)
    {
        var entity = await _dbContext.Albums.FindAsync(id);
        if (entity == null) return false;
        _dbContext.Albums.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<GetMediaTypeDto>> GetAllMediaTypesAsync()
    {
        var mediaTypes = await _dbContext.MediaTypes.AsNoTracking().ToListAsync();
        return mediaTypes.Select(m => new GetMediaTypeDto { MediaTypeId = m.MediaTypeId, Name = m.Name });
    }

    public async Task<GetMediaTypeDto?> GetMediaTypeByIdAsync(int id)
    {
        var m = await _dbContext.MediaTypes.AsNoTracking().FirstOrDefaultAsync(x => x.MediaTypeId == id);
        if (m == null) return null;
        return new GetMediaTypeDto { MediaTypeId = m.MediaTypeId, Name = m.Name };
    }

    public async Task<int> InsertMediaTypeAsync(string name)
    {
        var entity = new MediaType { Name = name ?? string.Empty };
        _dbContext.MediaTypes.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity.MediaTypeId;
    }

    public async Task<bool> UpdateMediaTypeAsync(int id, string name)
    {
        var entity = await _dbContext.MediaTypes.FindAsync(id);
        if (entity == null) return false;
        entity.Name = name ?? string.Empty;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteMediaTypeAsync(int id)
    {
        var entity = await _dbContext.MediaTypes.FindAsync(id);
        if (entity == null) return false;
        _dbContext.MediaTypes.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<GetTrackDto>> GetAllTracksAsync()
    {
        var tracks = await _dbContext.Tracks.AsNoTracking().ToListAsync();
        return tracks.Select(t => new GetTrackDto 
        { 
            TrackId = t.TrackId, 
            Name = t.Name, 
            AlbumId = t.AlbumId, 
            GenreId = t.GenreId, 
            MediaTypeId = t.MediaTypeId, 
            Milliseconds = t.Milliseconds, 
            UnitPrice = t.UnitPrice 
        });
    }

    public async Task<GetTrackDto?> GetTrackByIdAsync(int id)
    {
        var t = await _dbContext.Tracks.AsNoTracking().FirstOrDefaultAsync(x => x.TrackId == id);
        if (t == null) return null;
        return new GetTrackDto 
        { 
            TrackId = t.TrackId, 
            Name = t.Name, 
            AlbumId = t.AlbumId, 
            GenreId = t.GenreId, 
            MediaTypeId = t.MediaTypeId, 
            Milliseconds = t.Milliseconds, 
            UnitPrice = t.UnitPrice 
        };
    }

    public async Task<int> InsertTrackAsync(GetTrackDto dto)
    {
        var entity = new Track 
        { 
            Name = dto.Name ?? string.Empty, 
            AlbumId = dto.AlbumId, 
            GenreId = dto.GenreId, 
            MediaTypeId = dto.MediaTypeId, 
            Milliseconds = dto.Milliseconds, 
            UnitPrice = dto.UnitPrice 
        };
        _dbContext.Tracks.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity.TrackId;
    }

    public async Task<bool> UpdateTrackAsync(int id, GetTrackDto dto)
    {
        var entity = await _dbContext.Tracks.FindAsync(id);
        if (entity == null) return false;
        entity.Name = dto.Name ?? string.Empty;
        entity.AlbumId = dto.AlbumId;
        entity.GenreId = dto.GenreId;
        entity.MediaTypeId = dto.MediaTypeId;
        entity.Milliseconds = dto.Milliseconds;
        entity.UnitPrice = dto.UnitPrice;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTrackAsync(int id)
    {
        var entity = await _dbContext.Tracks.FindAsync(id);
        if (entity == null) return false;
        _dbContext.Tracks.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
