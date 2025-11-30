namespace Catalog.API.Features.MediaTypes.DTOs;

public class GetMediaTypeDto
{
    public int MediaTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
}
