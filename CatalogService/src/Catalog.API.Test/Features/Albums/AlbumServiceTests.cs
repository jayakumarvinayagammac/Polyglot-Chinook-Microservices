using Catalog.API.Features.Albums.DTOs;
using Catalog.API.Features.Albums.Services;
using Xunit;

namespace Catalog.API.Test.Features.Albums;

public class AlbumServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldCreateAlbumAndReturnDto()
    {
        // Arrange
        var service = new AlbumService();
        var createDto = new CreateAlbumDto { Title = "Abbey Road", ArtistId = 1 };

        // Act
        var result = await service.CreateAsync(createDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Abbey Road", result.Title);
        Assert.Equal(1, result.ArtistId);
        Assert.True(result.AlbumId > 0);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllAlbums()
    {
        // Arrange
        var service = new AlbumService();
        var album1 = await service.CreateAsync(new CreateAlbumDto { Title = "Album 1", ArtistId = 1 });
        var album2 = await service.CreateAsync(new CreateAlbumDto { Title = "Album 2", ArtistId = 2 });

        // Act
        var result = await service.GetAllAsync();

        // Assert
        Assert.NotEmpty(result);
        Assert.True(result.Count() >= 2);
    }
}
