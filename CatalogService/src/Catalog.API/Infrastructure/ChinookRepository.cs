using Microsoft.Data.Sqlite;
using Catalog.API.Features.Genres.DTOs;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Models;
using Catalog.API.Features.Artists.DTOs;

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
        return await _dbContext.Genres.AsNoTracking()
            .Select(a => new GetArtistDto { ArtistId = a.GenreId, Name = a.Name })
            .ToListAsync();
    }

    public async Task<GetArtistDto?> GetArtistByIdAsync(int id)
    {
        var a = await _dbContext.Genres.AsNoTracking().FirstOrDefaultAsync(x => x.GenreId == id);
        if (a == null) return null;
        return new GetArtistDto { ArtistId = a.GenreId, Name = a.Name };        
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
}
