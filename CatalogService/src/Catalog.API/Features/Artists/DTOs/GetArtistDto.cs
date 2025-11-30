namespace Catalog.API.Features.Artists.DTOs;

public class GetArtistDto
{
    public int ArtistId { get; set; }
    public string Name { get; set; } = string.Empty;
}
