namespace Catalog.API.Features.Albums.DTOs;

public class GetAlbumDto
{
    public int AlbumId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ArtistId { get; set; }
}
