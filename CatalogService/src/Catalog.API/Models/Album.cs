namespace Catalog.API.Models;

public class Album
{
    public int AlbumId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ArtistId { get; set; }
}
