namespace Catalog.API.Features.Albums.DTOs;

public class CreateAlbumDto
{
    public string Title { get; set; } = string.Empty;
    public int ArtistId { get; set; }
}
