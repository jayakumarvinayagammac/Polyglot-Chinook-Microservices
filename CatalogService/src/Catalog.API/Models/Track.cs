namespace Catalog.API.Models;

public class Track
{
    public int TrackId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int AlbumId { get; set; }
    public int GenreId { get; set; }
    public int MediaTypeId { get; set; }
    public string? Composer { get; set; }
    public long? Milliseconds { get; set; }
    public long? Bytes { get; set; }
    public decimal? UnitPrice { get; set; }
    
}
