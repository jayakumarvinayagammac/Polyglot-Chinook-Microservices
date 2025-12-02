using Microsoft.Data.Sqlite;
using Catalog.API.Features.Genres.DTOs;
using Catalog.API.Features.Artists.DTOs;

namespace Catalog.API.Infrastructure;

public interface IChinookRepository
{
    /// <summary>
    /// Full path to the Chinook database file.
    /// </summary>
    string DbPath { get; }

    /// <summary>
    /// Create a new <see cref="SqliteConnection"/> configured to open the Chinook DB file.
    /// Caller is responsible for opening/disposing the connection.
    /// </summary>
    SqliteConnection CreateConnection();

    // Genre-related CRUD operations (EF Core backing)
    Task<IEnumerable<GetGenreDto>> GetAllGenresAsync();
    Task<GetGenreDto?> GetGenreByIdAsync(int id);
    Task<int> InsertGenreAsync(string name);
    Task<bool> UpdateGenreAsync(int id, string name);
    Task<bool> DeleteGenreAsync(int id);

    // Artist-related CRUD operations
    Task<IEnumerable<GetArtistDto>> GetAllArtistsAsync();
    Task<GetArtistDto?> GetArtistByIdAsync(int id);
    Task<int> InsertArtistAsync(string name);
    Task<bool> UpdateArtistAsync(int id, string name);
    Task<bool> DeleteArtistAsync(int id);
}
