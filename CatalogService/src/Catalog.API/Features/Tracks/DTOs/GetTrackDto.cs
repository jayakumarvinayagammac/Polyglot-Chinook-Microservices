namespace Catalog.API.Features.Tracks.DTOs;

public class GetTrackDto
{
    public int TrackId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int AlbumId { get; set; }
    public int GenreId { get; set; }
    public int MediaTypeId { get; set; }
    public long? Milliseconds { get; set; }
    public decimal? UnitPrice { get; set; }
}
