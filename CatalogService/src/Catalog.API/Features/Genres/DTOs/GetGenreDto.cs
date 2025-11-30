namespace Catalog.API.Features.Genres.DTOs;

public class GetGenreDto
{
    public int GenreId { get; set; }
    public string Name { get; set; } = string.Empty;
}
