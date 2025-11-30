using Catalog.API.Features.Artists.DTOs;
using Catalog.API.Features.Artists.Services;
using Xunit;

namespace Catalog.API.Test.Features.Artists;

public class ArtistServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldCreateArtistAndReturnDto()
    {
        // Arrange
        var service = new ArtistService();
        var createDto = new CreateArtistDto { Name = "The Beatles" };

        // Act
        var result = await service.CreateAsync(createDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("The Beatles", result.Name);
        Assert.True(result.ArtistId > 0);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnArtistWhenExists()
    {
        // Arrange
        var service = new ArtistService();
        var createDto = new CreateArtistDto { Name = "Pink Floyd" };
        var created = await service.CreateAsync(createDto);

        // Act
        var result = await service.GetByIdAsync(created.ArtistId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Pink Floyd", result.Name);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllArtists()
    {
        // Arrange
        var service = new ArtistService();
        await service.CreateAsync(new CreateArtistDto { Name = "Artist 1" });
        await service.CreateAsync(new CreateArtistDto { Name = "Artist 2" });

        // Act
        var result = await service.GetAllAsync();

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveArtist()
    {
        // Arrange
        var service = new ArtistService();
        var created = await service.CreateAsync(new CreateArtistDto { Name = "To Delete" });

        // Act
        var deleted = await service.DeleteAsync(created.ArtistId);
        var result = await service.GetByIdAsync(created.ArtistId);

        // Assert
        Assert.True(deleted);
        Assert.Null(result);
    }
}
