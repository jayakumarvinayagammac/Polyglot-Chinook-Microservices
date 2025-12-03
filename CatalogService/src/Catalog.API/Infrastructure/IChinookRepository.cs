using Microsoft.Data.Sqlite;
using Catalog.API.Features.Genres.DTOs;
using Catalog.API.Features.Artists.DTOs;
using Catalog.API.Features.Albums.DTOs;
using Catalog.API.Features.MediaTypes.DTOs;
using Catalog.API.Features.Tracks.DTOs;

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

    // Album-related CRUD operations
    Task<IEnumerable<GetAlbumDto>> GetAllAlbumsAsync();
    Task<GetAlbumDto?> GetAlbumByIdAsync(int id);
    Task<int> InsertAlbumAsync(string title, int artistId);
    Task<bool> UpdateAlbumAsync(int id, string title, int artistId);    
    Task<bool> DeleteAlbumAsync(int id);

    // MediaType-related CRUD operations
    Task<IEnumerable<GetMediaTypeDto>> GetAllMediaTypesAsync();
    Task<GetMediaTypeDto?> GetMediaTypeByIdAsync(int id);
    Task<int> InsertMediaTypeAsync(string name);
    Task<bool> UpdateMediaTypeAsync(int id, string name);
    Task<bool> DeleteMediaTypeAsync(int id);

    // Track-related CRUD operations
    Task<IEnumerable<GetTrackDto>> GetAllTracksAsync();
    Task<GetTrackDto?> GetTrackByIdAsync(int id);
    Task<int> InsertTrackAsync(GetTrackDto dto);
    Task<bool> UpdateTrackAsync(int id, GetTrackDto dto);
    Task<bool> DeleteTrackAsync(int id);
}
