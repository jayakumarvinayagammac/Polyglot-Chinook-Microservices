using Catalog.API.Features.Genres.DTOs;
using Catalog.API.Features.Genres.Services;
using Xunit;

namespace Catalog.API.Test.Features.Genres;

public class GenreServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldCreateGenreAndReturnDto()
    {
        // Arrange
        var service = new GenreService();
        var createDto = new CreateGenreDto { Name = "Rock" };

        // Act
        var result = await service.CreateAsync(createDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Rock", result.Name);
        Assert.True(result.GenreId > 0);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllGenres()
    {
        // Arrange
        var service = new GenreService();
        var genre1 = await service.CreateAsync(new CreateGenreDto { Name = "Rock" });
        var genre2 = await service.CreateAsync(new CreateGenreDto { Name = "Jazz" });

        // Act
        var result = await service.GetAllAsync();

        // Assert
        Assert.NotEmpty(result);
        Assert.True(result.Count() >= 2);
    }
}
